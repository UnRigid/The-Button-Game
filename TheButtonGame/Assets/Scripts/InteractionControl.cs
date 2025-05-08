using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractionControl : MonoBehaviour
{
    
    private GameObject _CamObject;
    private Camera _CamComponent;
    private PlayerControls _PlayerControls;
    [SerializeField]private GameObject InteractHolder;
    
    [SerializeField]private float MaxDistance = 2f;


    private void Start() {
        _CamObject = GameObject.FindGameObjectWithTag("MainCamera");
        _CamComponent = _CamObject.GetComponent<Camera>();
        
        _PlayerControls = new PlayerControls();
        _PlayerControls.PlayerInteractions.Enable();
        _PlayerControls.PlayerInteractions.Interact.performed += TriggerInteract;
        _PlayerControls.PlayerInteractions.DebugMultikey.performed += DebugMulti;

        InteractHolder = GameObject.FindGameObjectWithTag("InteractHolder");
        InteractHolder.SetActive(false);
    }

    private void Update() {
        if(GetInteractable() != null){
            InteractHolder.SetActive(true);

        }else{
            InteractHolder.SetActive(false);
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

    }
}

