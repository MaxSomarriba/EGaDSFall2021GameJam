using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfficeEntranceTrigger : MonoBehaviour
{
    public static bool isTriggered;

    void OnTriggerEnter2D(Collider2D ChangeScene) {
        isTriggered = true;
        Debug.Log("Triggered the office collider");
    }
}
