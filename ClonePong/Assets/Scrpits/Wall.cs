using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public bool isPlayerWall;
    // Start is called before the first frame update
    void Awake()
    {
        if (isPlayerWall)
        {
            var transformPosition = transform.position;
            transformPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(0,0,0), 0).x;
            transform.position = transformPosition;
        }
        else
        {
            var transformPosition = transform.position;
            transformPosition.x = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,0), 0).x;
            transform.position = transformPosition;
        }
    }

}
