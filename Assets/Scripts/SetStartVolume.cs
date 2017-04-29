using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour
{

    private MusicManager musicManager;

    // Use this for initialization
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (musicManager)
        {
            Debug.Log("Found music manager " + musicManager);
            float volume = PlayerPrefsManager.GetMasterVolume();
            musicManager.SetVolume(volume);
        }
        else
        {
            Debug.LogWarning("Haven't found the music manager, we can't set the master volume.");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
