using Unity.VisualScripting;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = transform.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(Random.Range(-1f,1f) * 10,0,-1), ForceMode.VelocityChange);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }

}
