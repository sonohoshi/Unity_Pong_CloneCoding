using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    private float radius;
    private Vector2 direction;

    void NewGame()
    {
        Awake();
        
    }
    
    void Awake()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        direction = new Vector2(x, y);
        radius = transform.localScale.x / 2;
    }
    
    void FixedUpdate()
    {
        transform.Translate(direction * speed * Time.deltaTime);
        if (transform.position.y < GameManager.BottomLeft.y + radius && direction.y < 0)
        {
            direction.y *= -1;
        }

        if (transform.position.y > GameManager.TopRight.y - radius && direction.y > 0)
        {
            direction.y *= -1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Brick"))
        {
            direction.x *= -1;
        }

        if (col.CompareTag("Wall"))
        {
            transform.position = new Vector2(0, 0);
            NewGame();
        }
    }
}
