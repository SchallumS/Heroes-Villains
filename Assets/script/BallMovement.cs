using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float initspeed = 10;
    [SerializeField] private float increasespeed = 0.55f;
    [SerializeField] private TextMeshProUGUI[] score;
    private Rigidbody2D rb;
    private int hitcounter;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke ("startBall", 2f);
    }

    void FixedUpdate ()
    {
        rb.velocity = Vector2.ClampMagnitude (rb.velocity, initspeed + (increasespeed * hitcounter));
    }
    
    private void startBall ()
    {
        rb.velocity = new Vector2(0, -1.0f) * (initspeed + increasespeed * hitcounter);
    }

    private void resetBall ()
    {
        rb.velocity = new Vector2 (0, 0);
        transform.position = new Vector2 (0, 0);
        hitcounter = 0;
        Invoke ("startBall", 2f);
    }

    private void playerBounce (Transform myObject)
    {
        hitcounter++;
        Vector2 posBall = transform.position;
        Vector2 playerPos = myObject.position;
        float xDirection = 0;
        float yDirection = 0;

        if (transform.position.y > 0)
        {
            yDirection = -1.0f;
        }
        else
        {
            yDirection = 1.0f;
        }
        xDirection = (posBall.x - playerPos.x) / myObject.GetComponent<Collider2D>().bounds.size.x;
        if (xDirection == 0)
        {
            xDirection = 0.25f;
        }
        rb.velocity = new Vector2(xDirection, yDirection) * (initspeed + (increasespeed * hitcounter));
    }

    private void OnCollisionEnter2D (Collision2D coli)
    {
        if(coli.gameObject.name == "Player 1" || coli.gameObject.name == "Player 2")
        {
            playerBounce (coli.transform);
        }
    }

    private void OnTriggerEnter2D(Collider2D colid)
    {
        if (transform.position.y > 0)
        {
            resetBall ();
            score[0].text = (int.Parse(score[0].text) + 1).ToString();
        }
        else if (transform.position.y < 0)
        {
            resetBall ();
            score[1].text = (int.Parse(score[1].text) + 1).ToString();
        }
        else
        {

        }
    }

    /*IEnumerator displayScore ()
    {
        
    }*/

}
