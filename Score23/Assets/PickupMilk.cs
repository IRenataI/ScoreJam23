using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< Updated upstream:Score23/Assets/Mini First Person Controller/Scripts/Milk/Pickup.cs
public class Pickup : MonoBehaviour
=======
public class PickupMilk : AttackType
>>>>>>> Stashed changes:Score23/Assets/PickupMilk.cs
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
