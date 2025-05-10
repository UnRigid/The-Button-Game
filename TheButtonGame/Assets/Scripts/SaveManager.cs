using UnityEngine;
using System.IO;
using UnityEditor.Playables;

public class SaveManager : MonoBehaviour
{

    public static readonly string SaveDirectory = Application.dataPath + "/Saves";
    public static readonly string SettingsFile = SaveDirectory + "/UserSettings.json";
    public static readonly string SavesFile = SaveDirectory + "/UserSaves.json";
    
    private void OnEnable() {
        if(!Directory.Exists(SaveDirectory)){
            Directory.CreateDirectory(SaveDirectory);
            PlayerProgress playerProgress = new PlayerProgress{
                Slot1_Index = 4,
                Slot2_Index = 4
            };

            string json = JsonUtility.ToJson(playerProgress);
            File.WriteAllText(SavesFile, json);

            SaveSettings();
            Debug.Log("Done");
        }
        ReadSettings();
    }

    public static void SaveSettings(){
        PlayerSettings playerSettings = new PlayerSettings{
            volume = Settings.volume,
            ResolutionIndex = Settings.ResolutionIndex,
            Sensitivity = Settings.Sensitivity,
            init_load = Settings.initial_load
        };

        string json = JsonUtility.ToJson(playerSettings);
        File.WriteAllText(SettingsFile, json);
    }

    public void ReadSettings(){
        string json = File.ReadAllText(SettingsFile);

        PlayerSettings playerSettings = JsonUtility.FromJson<PlayerSettings>(json);

        Settings.volume = playerSettings.volume;
        Settings.ResolutionIndex = playerSettings.ResolutionIndex;
        Settings.Sensitivity = playerSettings.Sensitivity;
        Settings.initial_load = playerSettings.init_load;
        Settings.Slot = playerSettings.Slot;
    }

    public static void SaveProgress(int Slot, int Index){

        string json = File.ReadAllText(SavesFile);
        PlayerProgress playerProgress = JsonUtility.FromJson<PlayerProgress>(json);



        switch(Slot){
            case 1:
                playerProgress.Slot1_Index = Index;
                break;
            case 2:
                playerProgress.Slot2_Index = Index;
                break;
            default:
                break;
        }

        json = JsonUtility.ToJson(playerProgress);

        File.WriteAllText(SavesFile, json);
    }

    public static int ReadProgress(int Slot){
        string json = File.ReadAllText(SavesFile);
        PlayerProgress playerProgress = JsonUtility.FromJson<PlayerProgress>(json);

        switch(Slot){
            case 1: return playerProgress.Slot1_Index;
            case 2: return playerProgress.Slot2_Index;
        }
        Debug.LogError("Slot out of reach");
        return 0;
    }

    public static void Wipe(){
        

        Settings.volume = .7f;
        Settings.ResolutionIndex = 1;
        Settings.Sensitivity = .7f;
        Settings.initial_load = true;
        Settings.Slot = 1;

        SaveSettings();

        ClearSave(1);
        ClearSave(2);

        Debug.Log("Wiped");

    }

    public static void ClearSave(int Slot){
        string json = File.ReadAllText(SavesFile);

        PlayerProgress playerProgress = JsonUtility.FromJson<PlayerProgress>(json);
        switch(Slot){
            case 1: playerProgress.Slot1_Index = 4; break;
            case 2: playerProgress.Slot2_Index = 4; break;
        }

        json = JsonUtility.ToJson(playerProgress);

        File.WriteAllText(SavesFile, json);

    }

    private class PlayerProgress{
        public int Slot1_Index;
        public int Slot2_Index;

    }

    private class PlayerSettings{
        public float volume;
        public int ResolutionIndex;
        public float Sensitivity;
        public bool init_load;
        public int Slot=1;
    }

}


