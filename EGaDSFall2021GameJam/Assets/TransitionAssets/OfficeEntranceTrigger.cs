using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeEntranceTrigger : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D ChangeScene) {
        Debug.Log("Triggered the office collider");
        // KitchenEntranceTrigger.LoadScene("");
    }
}
