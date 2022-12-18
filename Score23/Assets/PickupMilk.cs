using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMilk : AttackType
{
    static public float AddHp = 30;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //HP += AddHp;
            Destroy(gameObject);
        }
    }


}
