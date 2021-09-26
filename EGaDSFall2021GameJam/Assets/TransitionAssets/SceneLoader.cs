using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{

    // AsyncOperation asyncLoad;
    string sceneLabel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (KitchenEntranceTrigger.isTriggered) {
            // SceneManager.LoadScene(sceneName: "restaurantScene");
            // StartCoroutine(LoadYourAsyncScene(0));
        // } else if (OfficeEntranceTrigger.isTriggered) {
            // SceneManager.LoadScene(sceneName: "OfficeScene");
            // StartCoroutine(LoadYourAsyncScene(1));
        // }
    }

     IEnumerator LoadYourAsyncScene(int scene)
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        // if (scene == 1) {
        //     sceneLabel = "OfficeScene";
        // } else {
        //     sceneLabel = "restaurantScene";
        // }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneLabel);
        
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
