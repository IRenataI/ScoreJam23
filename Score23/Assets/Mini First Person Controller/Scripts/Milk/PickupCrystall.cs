using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCrystall : FirstPersonMovement_Mod
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<FirstPersonMovement_Mod>().ChangeSpeed(4);
            Destroy(gameObject);
        }
    }

}
