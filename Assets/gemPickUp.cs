using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gemPickUp : MonoBehaviour
{
    public void OnTriggerEnter(Collider collisionInfo)
    {
        if (collisionInfo.CompareTag("Player"))
        {
            Debug.Log("gem Collected");
        }
    }
}
