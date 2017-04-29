using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsController : MonoBehaviour
{

    public Slider volumeSlider;
    public Slider diffilcultySlider;

    public LevelManager LevelManager;

    private MusicManager musicManager;

    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        if (volumeSlider != null)
        {
            volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        }
        if (diffilcultySlider != null)
        {
            diffilcultySlider.value = PlayerPrefsManager.GetDifficulty();
        }
    }

    void Update()
    {
        if (volumeSlider != null && musicManager != null)
        {
            musicManager.SetVolume(volumeSlider.value);
        }
    }


    public void SaveAndExit()
    {
        if(volumeSlider != null)
            PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        if(diffilcultySlider != null)
            PlayerPrefsManager.SetDifficulty(diffilcultySlider.value);

        if(LevelManager != null)
            LevelManager.LoadLevel("01a Start");
    }

    public void SetDefault()
    {
        if (volumeSlider != null)
            volumeSlider.value = 0.8f;
        if (diffilcultySlider != null)
            diffilcultySlider.value = 2f;
    }



}
