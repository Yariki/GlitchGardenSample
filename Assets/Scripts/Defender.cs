using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour
{
    public int spawnCost = 100;
    private StarsDisplay startDisplay;

    void Start()
    {
        startDisplay = GameObject.FindObjectOfType<StarsDisplay>();
    }

    public void AddStars(int amount)
    {
        if (startDisplay)
        {
            startDisplay.AddStars(amount);
        }
    }
}
