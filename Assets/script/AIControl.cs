using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIControl : MonoBehaviour
{
    [SerializeField] public float speed;
    [SerializeField] private GameObject ball;
    private Vector2 aiMove;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ai_control ();
    }
    void ai_control ()
    {
        if(ball.transform.position.x < transform.position.x - 0.5f)
        {
            aiMove = new Vector2 (-1, 0);
        }
        else if (ball.transform.position.x > transform.position.x + 0.5f)
        {
            aiMove  =  new Vector2 (+1, 0);
        }
        else
        {
            aiMove = new Vector2 (0, 0);
        }
    }

    void FixedUpdate ()
    {
        rb.velocity = aiMove * speed;
    }

    void OnCollisionEnter2D (Collision2D collision)
    {
        if(collision.gameObject.name == "Basic Ball")
        {
            //frappeEffect.Play();
        }
    }
}
