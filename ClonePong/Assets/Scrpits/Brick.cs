using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private readonly float speed = 10f;
    private bool isPlayer;
    private bool isMoving = false;
    private Transform ball;

    void Awake()
    {
        ball = GameObject.FindWithTag("Ball").transform;
    }
    
    void FixedUpdate()
    {
        Vector3 worldPos = Camera.main.WorldToViewportPoint(this.transform.position);
        if (worldPos.x < 0f) worldPos.x = 0f;
        if (worldPos.y < 0f) worldPos.y = 0f;
        if (worldPos.x > 1f) worldPos.x = 1f;
        if (worldPos.y > 1f) worldPos.y = 1f;
        this.transform.position = Camera.main.ViewportToWorldPoint(worldPos);
        
        if (isPlayer)
        {
            transform.Translate(0,Input.GetAxis("Vertical") * Time.deltaTime * speed,0);
        }
        else
        {
            AIMoving();
        }
    }

    public bool SetPlayer(bool isPlayer)
    {
        this.isPlayer = isPlayer;
        return this.isPlayer;
    }

    void AIMoving()
    {
        float count = 0f;
        Vector2 pastPos = transform.position;

        var movePos = Vector2.Lerp(ball.position, transform.position, 0.25f);
        movePos = movePos.normalized;
        transform.Translate(0, movePos.y * Time.deltaTime, 0);
    }
}
