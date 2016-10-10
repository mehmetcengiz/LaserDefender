using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{
    public static MusicPlayer instance = null; // Setup Singleton Pattern So Only One Music Player Object Ever Instantiats
    public AudioClip startClip;
    public AudioClip gameClip;
    public AudioClip endClip;
    private AudioSource music;

    // Use this for initialization
    void Awake()
    {
        // If a MusicPlayer Already exists
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            print("Duplicate music player self destructing");
        }
        else
        {
            // Don't destroy this game object between scenes (i.e play music all the time between scenes)
            instance = this; // Claim the instance if it is null i.e. 1st time round
            GameObject.DontDestroyOnLoad(gameObject);
            music = GetComponent<AudioSource>();
            //Add a DELEGATE to this to get notifications when a scene is load and thus play the appropriate level music
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
    }

    //Load The Appropriate Music Depending On The Scene That Was Loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        music.Stop();
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Debug.Log("MusicPlayer: Loaded Level " + SceneManager.GetActiveScene().buildIndex);
            music.clip = startClip;
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            Debug.Log("MusicPlayer: Loaded Level " + SceneManager.GetActiveScene().buildIndex);
            music.clip = gameClip;
        }
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            Debug.Log("MusicPlayer: Loaded Level " + SceneManager.GetActiveScene().buildIndex);
            music.clip = endClip;
        }
        music.loop = true;
        music.Play();
    }
}