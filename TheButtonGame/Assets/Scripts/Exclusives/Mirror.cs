using UnityEngine;

public class Mirror : MonoBehaviour
{

    [SerializeField]GameObject PlayerMirrored;

    private void Update()
    {
        PlayerMirrored.transform.position = new Vector3(transform.position.x, 2f, transform.position.z * -1);
    }
}
