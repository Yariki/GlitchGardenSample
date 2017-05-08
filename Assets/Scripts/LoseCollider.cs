using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour
{

    private LevelManager levelManager;

    // Use this for initialization
    void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }

    void OnTriggerEnter2D(Collider2D collider2)
    {
        if (levelManager)
        {
            levelManager.LoadLevel("03b Lose");
        }
    }
}
