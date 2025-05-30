using UnityEngine;
using System;

public class KeyScript : MonoBehaviour, IInteraction
{

    public static event Action PickUpKey;

    

    public void Interact()
    {
        PickUpKey?.Invoke();
        Destroy(this.gameObject);
    }

}
