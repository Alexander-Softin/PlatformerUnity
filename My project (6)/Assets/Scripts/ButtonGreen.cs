using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGreen : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxCollider;

    public GameObject wall;

    public bool close = false;
    private void Update()
    {
        if(close == true && wall.transform.position.y < 0.02f)
        {
            wall.transform.Translate(Vector2.up * Time.deltaTime);
        }
    }
    private void Awake()
    {
        //эти две строки помогут получить ссылки для нашего rigidbody и animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player1" && transform.position.y > 1.8f)
        {
            transform.Translate(Vector2.down * Time.deltaTime);
        }
        else if (collision.tag == "Player1" && wall.transform.position.y > -2f)
        {
            wall.transform.Translate(Vector2.down * Time.deltaTime);
        }
        close = false;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        transform.position = new Vector2(transform.position.x, 2.18f);
        close = true;
    }
}
