using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private GameObject[] infini;
    [SerializeField] private GameObject lm;
    [SerializeField] private GameObject oklm;
    private Rigidbody2D rb;
    int mode_c = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GetComponent<AIControl>().enabled = false;
         GetComponent<Player2>().enabled = false;
        mode_c = PlayerPrefs.GetInt("mode");
        if (mode_c == 2)
        {
            GetComponent<AIControl>().enabled = true;
        }
        else
        {
            GetComponent<Player2>().enabled = true;
        }
    }

    void Update()
    {
        player1Movement();
    }
    

    //Movement of player

    private void player1Movement ()
    {
        int  i =  0;
        while (i < Input.touchCount) {
            Touch touch = Input.GetTouch(i);
            Vector3 touchPosition = new Vector3 (touch.position.x, touch.position.y, 0);
            touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);
            if (touch.phase == TouchPhase.Moved && (touchPosition.y >= lm.transform.position.y) &&(touchPosition.x > infini[0].transform.position.x && touchPosition.x < infini[1].transform.position.x))
            {
                transform.position = new Vector2 (touchPosition.x, transform.position.y);
            }
            ++i;
        }
    }
}
