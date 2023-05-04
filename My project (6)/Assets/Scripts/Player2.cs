using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    //пол€

    [SerializeField] private float speed;//открытый дл€ редакции в unity
    [SerializeField] private LayerMask groundLayer;
   
    private Rigidbody2D body;
    private Animator anim;

   
    private bool player;
    private BoxCollider2D boxCollider;


    private void Awake()
    {
        //эти две строки помогут получить ссылки дл€ нашего rigidbody и animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //как ты можешь заметить
        //здесь уже horizontal2 и перс

        //управл€етс€ на клавиши a d

        float horizontalInput = Input.GetAxis("Horizontal2");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(4, 4, 4);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-4, 4, 4);

        //прыжок
        if ((Input.GetKey(KeyCode.W) && isGrounded() ) || (Input.GetKey(KeyCode.W) && player ))
            Jump();
        

        anim.SetBool("run2", horizontalInput != 0);
        anim.SetBool("grounded", isGrounded());
    }
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump2");
        
        player = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            
            player = true;

        }
    }
    
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

   
}
