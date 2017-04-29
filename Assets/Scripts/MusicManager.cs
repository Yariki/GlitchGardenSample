using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour
{

	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource soundSource;

    // Use this for initialization
    void Awake()
    {
    	DontDestroyOnLoad(gameObject);
    	Debug.Log("Don't destroy player");
    }
    
    void Start()
    {
    	soundSource = GetComponent<AudioSource>();
    }
    
    void OnLevelWasLoaded(int level)
    {
        if (levelMusicChangeArray != null && levelMusicChangeArray.Length > 0 && level < levelMusicChangeArray.Length && levelMusicChangeArray[level] != null)
		{
			var clip = levelMusicChangeArray[level];
		    Debug.Log("Playing clip: " + clip);
			if(soundSource != null)
			{
				soundSource.clip = clip;
			    soundSource.loop = true;
				soundSource.Play();
			}
		}
    }

    public void SetVolume(float volumeSliderValue)
    {
        if (soundSource != null)
        {
            soundSource.volume = volumeSliderValue;
        }
    }
}
