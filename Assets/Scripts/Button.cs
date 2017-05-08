using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour
{

    public GameObject currentPrefab;
    public static GameObject currentSelectredPrefab;
    private Button[] buttons;
    private Text textCost;

    // Use this for initialization
    void Start()
    {
        buttons = GameObject.FindObjectsOfType<Button>();

        textCost = GetComponentInChildren<Text>();
        if (textCost)
        {
            textCost.text = currentPrefab.GetComponent<Defender>().spawnCost.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {
        foreach (var button in buttons)
        {
            var sR = button.GetComponent<SpriteRenderer>();
            if (sR != null)
            {
                sR.color = Color.black;
            }
        }

        var spriteRender = GetComponent<SpriteRenderer>();
        if (spriteRender != null)
        {
            spriteRender.color = Color.white;
        }
        currentSelectredPrefab = currentPrefab;

        print(currentSelectredPrefab);
    }
}
