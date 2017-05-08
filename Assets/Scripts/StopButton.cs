using UnityEngine;
using System.Collections;

public class StopButton : MonoBehaviour
{

    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnMouseDown()
    {
        if (levelManager)
        {
            levelManager.LoadLevel("01a Start");
        }

    }
}
