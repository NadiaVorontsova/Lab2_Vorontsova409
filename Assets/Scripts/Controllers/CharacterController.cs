using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterController : MonoBehaviour
{
    public GameController Game;
    private Rigidbody2D rb2;
    private Vector2 velocity;
   
   
    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        velocity = new Vector2(1f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 oldPosition = transform.position;
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb2.AddForce(new Vector2(-2f, 0f), ForceMode2D.Impulse);
            //rb2.MovePosition(rb2.position - velocity);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.position = new Vector3(oldPosition.x + speed , oldPosition.y, oldPosition.z);
            rb2.AddForce(new Vector2(2f, 0f), ForceMode2D.Impulse);
            //rb2.MovePosition(rb2.position + velocity);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb2.AddForce(new Vector2(0f, 3f), ForceMode2D.Impulse);
            //rb2.velocity = new Vector2(0, 5);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Worm":
                Destroy(collision.gameObject);
                Game.WormWasAte();
                break;
            case "LineOfDeath":
                SceneManager.LoadScene("GameOver");
                break;
        }  
    }
}
