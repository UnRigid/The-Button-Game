using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InteractionControl : MonoBehaviour
{
    
    private GameObject _CamObject;
    private Camera _CamComponent;
    private PlayerControls _PlayerControls;
    private Button MainMenuButton;
    private Button QuitButton;
    private Button SettingsButton;
    [SerializeField]private GameObject InteractHolder;
    [SerializeField]private GameObject PauseMenu;
    
    [SerializeField]private float MaxDistance = 2f;


    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _CamObject = GameObject.FindGameObjectWithTag("MainCamera");
        _CamComponent = _CamObject.GetComponent<Camera>();
        PauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");

        MainMenuButton = PauseMenu.transform.GetChild(0).GetChild(0).GetComponent<Button>();
        SettingsButton = PauseMenu.transform.GetChild(0).GetChild(1).GetComponent<Button>();
        QuitButton = PauseMenu.transform.GetChild(0).GetChild(2).GetComponent<Button>();

        MainMenuButton.onClick.AddListener(ReturnMainMenu);
        SettingsButton.onClick.AddListener(OptionsFromPause);
        QuitButton.onClick.AddListener(Quit);
        
        _PlayerControls = new PlayerControls();
        _PlayerControls.PlayerInteractions.Enable();
        _PlayerControls.PlayerInteractions.Interact.performed += TriggerInteract;
        _PlayerControls.PlayerInteractions.DebugMultikey.performed += DebugMulti;
        _PlayerControls.PlayerInteractions.Pause.performed += TogglePauseByPlayer;

        PauseMenu.SetActive(false);
        

        InteractHolder = GameObject.FindGameObjectWithTag("InteractHolder");
        InteractHolder.SetActive(false);

        if(Settings.OriginIndex == GameObject.GetScene(gameObject.GetInstanceID()).buildIndex){
            TogglePause();
        }
    }

    private void Update() {
        if(!PauseMenu.activeSelf){
            if(GetInteractable() != null){
                InteractHolder.SetActive(true);

            }else{
                InteractHolder.SetActive(false);
            }
        }
        
    }

    

    void TriggerInteract(InputAction.CallbackContext callbackContext){
        Transform transform = GetInteractable();
        if(transform  != null){
            if(transform.TryGetComponent(out IInteraction interaction)){
                interaction.Interact();
            }
        }
    }

    public Transform GetInteractable(){
        Ray ray = _CamComponent.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
    
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, MaxDistance, 1 << 7)){
            return hit.transform;
        }else{
            return null;
        }
    }

    void DebugMulti(InputAction.CallbackContext callbackContext){
        Debug.Log("Debug Triggered");
        SoundManager.PlaySound(SoundType.ButtonPress);
    }

    void TogglePauseByPlayer(InputAction.CallbackContext callbackContext){
        TogglePause();
    }

    void TogglePause(){
        bool IsPaused = PauseMenu.activeSelf;
        if(IsPaused){
            Time.timeScale = 1;//unpause
            
            AudioListener.pause = false;
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }else{
            Time.timeScale = 0;//pause
            
            if(InteractHolder.activeSelf){
                InteractHolder.SetActive(false);
            }

            AudioListener.pause = true;
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        PauseMenu.SetActive(!IsPaused);

    }

    public void ReturnMainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
        
    }

    public void OptionsFromPause(){
        Time.timeScale = 1;
        Settings.OriginIndex = GameObject.GetScene(gameObject.GetInstanceID()).buildIndex;
        
        SceneManager.LoadSceneAsync("Settings");
        
    }

    public void Quit(){
        Application.Quit();
    }

    void OnDrawGizmos(){
        if(_CamComponent != null && _CamObject != null){
            
            Ray ray = _CamComponent.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(_CamObject.transform.position, MaxDistance);
            Gizmos.color = Color.red;
            Gizmos.DrawRay(ray);
        }
            
    }

    
    private void OnDestroy() {
        _PlayerControls.PlayerInteractions.Disable();
        MainMenuButton.onClick.RemoveListener(ReturnMainMenu);
        SettingsButton.onClick.RemoveListener(OptionsFromPause);
        QuitButton.onClick.RemoveListener(Quit);
    }
}

