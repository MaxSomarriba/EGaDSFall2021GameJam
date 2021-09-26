using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    AsyncOperation asyncLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KitchenEntranceTrigger.isTriggered) {
            StartCoroutine(LoadYourAsyncScene(0));
        } else if (OfficeEntranceTrigger.isTriggered) {
            StartCoroutine(LoadYourAsyncScene(1));
        }
    }

     IEnumerator LoadYourAsyncScene(int scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        if (scene == 1) {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("OfficeScene");
        } else {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("restaurantScene");
        }
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
