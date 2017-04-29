using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour
{
    private const string MASTER_VOLUME_KEY = "master_volume";
    private const string DIFFICULTY_KEY = "difficulty";
    private const string LEVEL_KEY = "level_unloked_";


    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master Volume out of range...");
        }
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockLevel(int level)
    {
        if (level <= Application.levelCount - 1)
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level,1); // use 1 for true;
        }
        else
        {
            Debug.LogError("Trying to unlock missing level");
        }
    }


    public static bool IsLevelUnlocked(int level)
    {
        var key = LEVEL_KEY + level;
        return PlayerPrefs.HasKey(key) && PlayerPrefs.GetInt(key) == 1;
    }

    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty hasn't appropriate value...");
        }
    }

    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }

}
