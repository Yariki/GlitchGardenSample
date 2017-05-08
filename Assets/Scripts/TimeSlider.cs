using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeSlider : MonoBehaviour
{
    public float levelSeconds;
    
    private Slider slider;
    private LevelManager levelManager;
    private AudioSource audioSource;
    private GameObject winLabel;
    private bool isLevelEnd = false;


    // Use this for initialization
    void Start()
    {
        slider = GetComponent<Slider>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        audioSource = GetComponent<AudioSource>();

        InitWinLabel();
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = Time.timeSinceLevelLoad / levelSeconds;

        bool isTimeUp = Time.timeSinceLevelLoad >= levelSeconds;
        if (isTimeUp && !isLevelEnd)
        {
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        isLevelEnd = true;
        audioSource.Play();
        ShowWinLabel();
        Invoke("LoadNextLevel", audioSource.clip.length);
    }

    private void DestroyAllTaggedObjects()
    {
        var allTaggedObjects = GameObject.FindGameObjectsWithTag("destroyOnWin");
        foreach (GameObject allTaggedObject in allTaggedObjects)
        {
            Destroy(allTaggedObject);
        }
    }

    void LoadNextLevel()
    {
        if (levelManager)
        {
            levelManager.LoadNextLevel();
        }
    }

    void InitWinLabel()
    {
        winLabel = GameObject.Find("WinLabel");
        if (winLabel)
        {
            winLabel.SetActive(false);
        }
    }

    void ShowWinLabel()
    {
        if (winLabel)
        {
            winLabel.SetActive(true);
        }
    }

}
