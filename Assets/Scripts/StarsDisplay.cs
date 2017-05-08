using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarsDisplay : MonoBehaviour
{

    private Text starsText;
    private int stars = 100;

    // Use this for initialization
    void Start()
    {
        starsText = GetComponent<Text>();
        UpdateText();
    }


    public void AddStars(int amount)
    {
        stars += amount;
        UpdateText();
    }

    public bool UserStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateText();
            return true;
        }
        return false;
    }

    private void UpdateText()
    {
        if (starsText)
        {
            starsText.text = stars.ToString();
        }
    }
}
