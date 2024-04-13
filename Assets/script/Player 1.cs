using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] infini;
    [SerializeField] private GameObject lm;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        player1Movement();
    }
    

    //Movement of player

    private void player1Movement ()
    {
        int i = 0;
        while ( i < Input.touchCount) {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = new Vector3 (touch.position.x, touch.position.y, 0);
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            if (touch.phase == TouchPhase.Moved && (touchPosition.y <= lm.transform.position.y) &&(touchPosition.x > infini[0].transform.position.x && touchPosition.x < infini[1].transform.position.x))
            {
                transform.position = new Vector2 (touchPosition.x, transform.position.y);
            }
            ++i;
        }
    }
}
