using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInController : MonoBehaviour
{

    public float fadeInTime;


    private Image ImagePanel;
    private Color currentColor = Color.black;


    // Use this for initialization
    void Start()
    {
        ImagePanel = GetComponent<Image>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            float alphaChange = Time.deltaTime / fadeInTime;
            currentColor.a -= alphaChange;
            ImagePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
