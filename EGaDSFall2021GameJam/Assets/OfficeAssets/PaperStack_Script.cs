using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperStack_Script : MonoBehaviour
{

    public static int stackSize = 10;
    public float TimeSeconds = 5;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTimer());        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnTimer() {
        while (true) {
            yield return new WaitForSeconds(TimeSeconds);
            stackSize++;
        }
    }
}
