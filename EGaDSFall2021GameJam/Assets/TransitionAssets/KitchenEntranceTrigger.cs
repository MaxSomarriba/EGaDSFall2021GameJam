using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenEntranceTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ChangeScene) {
        Debug.Log("Triggered the kitchen collider");
        // KitchenEntranceTrigger.LoadScene("");
    }
}
