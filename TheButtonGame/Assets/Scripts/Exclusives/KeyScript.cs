using UnityEngine;
using System;

public class KeyScript : MonoBehaviour, IInteraction
{


    [SerializeField]AudioClip KeySound;
    public static event Action PickUpKey;

    

    public void Interact()
    {
        SoundManager.PlayCustomSound(KeySound);
        PickUpKey?.Invoke();
        Destroy(this.gameObject);
    }

}
