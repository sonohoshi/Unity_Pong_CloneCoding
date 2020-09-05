using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Manager;
    public static Vector2 BottomLeft;
    public static Vector2 TopRight;
    
    public GameObject Ball;
    public GameObject Brick;

    private Vector2 playerPosition;
    private Vector2 comPosition;
    
    void Awake()
    {
        BottomLeft = Camera.main.ScreenToWorldPoint(new Vector3(0, 0));
        TopRight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height));

        playerPosition = new Vector2(BottomLeft.x, 0);
        comPosition = new Vector2(TopRight.x, 0);
        
        Instantiate(Ball);
        var plrBrick = Instantiate(Brick, playerPosition, Quaternion.identity).GetComponent<Brick>();
        plrBrick.SetPlayer(true);
        var comBrick = Instantiate(Brick, comPosition, Quaternion.identity).GetComponent<Brick>();
        comBrick.SetPlayer(false);
    }
}