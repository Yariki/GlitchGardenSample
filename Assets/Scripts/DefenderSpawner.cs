using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;
    private GameObject parent;

    private const string PARENT_NAME = "Defenders";
    private const string GAME_CAMERA = "GameCamera";

    // Use this for initialization
    void Start()
    {
        parent = GameObject.Find(PARENT_NAME);
        if (parent == null)
        {
            parent = new GameObject(PARENT_NAME);
        }
    }

    void OnMouseDown()
    {
        var rawPos = CalculateWorlPositionOfMouceClick();
        var roundPos = SnapToGrid(rawPos);
        var newDefender = Instantiate(Button.currentSelectredPrefab, new Vector3(roundPos.x, roundPos.y),
            Quaternion.identity) as GameObject;
        newDefender.transform.parent = parent.transform;
    }

    Vector2 SnapToGrid(Vector2 rawPos)
    {
        var newX = Mathf.RoundToInt(rawPos.x);
        var newY = Mathf.RoundToInt(rawPos.y);
        return new Vector2(newX,newY);
    }

    Vector2 CalculateWorlPositionOfMouceClick()
    {
        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;
        float distanceToCamera = 10f;
        var triple = new Vector3(x,y,distanceToCamera);

        var worldPos = myCamera.ScreenToWorldPoint(triple);
        return new Vector2(worldPos.x,worldPos.y);
    }


    
}
