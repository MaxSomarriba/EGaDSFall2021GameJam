using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManagerScript : MonoBehaviour
{

    static MusicManagerScript instance;

    // Drag in the .mp3 files here, in the editor
    public AudioClip[] MusicClips;

    public AudioSource Audio;
    
    // Singelton to keep instance alive through all scenes
    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);

        // Hooks up the 'OnSceneLoaded' method to the sceneLoaded event
    }
    void Update()
    {
        Audio = GetComponent<AudioSource>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "restaurantScene")
        {
            Audio.clip = MusicClips[0];
            
        }
        OnSceneLoaded(currentScene);
    }
    void OnSceneLoaded(Scene scene)
    {
        Debug.Log("ANYTHING");
        Audio.Play();
    }
}