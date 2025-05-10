using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
public class PlayerContoller : MonoBehaviour
{
    
    private Rigidbody PlayerRB;
    private GameObject PlayerViewCam;
    private static PlayerControls _PlayerControls;
    [Header("Movement")]
    public float MoveSpd=5f;
    
    
    [SerializeField] float LookMultiplier = 15f;
    public float MaxAngle = 80f;
    public float MinAngle = 80f;

    private void Awake() {
        GameObject[] PlayerInstances = GameObject.FindGameObjectsWithTag("Player");
        foreach(GameObject Instance in PlayerInstances){
            if(Instance != gameObject){
                Destroy(Instance);
            }
        }
        
    }

    private void Start() {
        PlayerRB = GetComponent<Rigidbody>();
        PlayerViewCam = GameObject.FindGameObjectWithTag("MainCamera");
        
        _PlayerControls = new PlayerControls();
        _PlayerControls.PlayerMovement.Enable();

        
        SaveManager.SaveProgress(Settings.Slot, SceneManager.GetActiveScene().buildIndex);
        

    }

    private void FixedUpdate() {
        Move();
        Look();
    }

    private void Move(){
        Vector2 _InputRead =  _PlayerControls.PlayerMovement.Move.ReadValue<Vector2>();
        Vector3 MoveDirection = transform.forward * _InputRead.y + transform.right * _InputRead.x;
        Vector3 _Move = new Vector3(MoveDirection.x , PlayerRB.linearVelocity.y , MoveDirection.z);

        PlayerRB.linearVelocity = _Move * MoveSpd * 20 * Time.fixedDeltaTime;
        
        
    }

    private void Look(){
        Vector2 _InputRead = _PlayerControls.PlayerMovement.Look.ReadValue<Vector2>();
        float _xDelta = _InputRead.x * Settings.Sensitivity * .5f * Time.fixedDeltaTime * LookMultiplier;
        float _yDelta = _InputRead.y * Settings.Sensitivity * .5f * Time.fixedDeltaTime * LookMultiplier;
        
        //Lateral Rotation
        this.transform.Rotate(Vector3.up, _xDelta);

        //Horizontal Rotation
        PlayerViewCam.transform.Rotate(Vector3.right, -_yDelta);

        //Clamp vertical
        float _yRot = PlayerViewCam.transform.rotation.eulerAngles.x;
        
        if(_yRot < 360 - MaxAngle && _yRot > 270){
            _yRot = 360 - MaxAngle;
        }
        else if(_yRot > MinAngle && _yRot < 90){
            _yRot = MinAngle;
        }
        //Debug.Log(_yRot + "  " + PlayerViewCam.transform.rotation.eulerAngles.x );
        PlayerViewCam.transform.localEulerAngles = new  Vector3(_yRot, 0,0);
        
    }

    


    private void OnDestroy() {
        _PlayerControls.PlayerMovement.Disable();
    }

}
