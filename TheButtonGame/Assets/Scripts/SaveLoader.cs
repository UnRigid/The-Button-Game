using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoader : MonoBehaviour
{
    
    public void LoadSave(int Slot){
        Settings.Slot = Slot;
        // System.GC.Collect();
        SceneManager.LoadScene(SaveManager.ReadProgress(Slot));
    }

    public void ClearSave(int Slot){
        SaveManager.ClearSave(Slot);
    }

    public void GoBack(){
        SceneManager.LoadScene(0);
    }

}
