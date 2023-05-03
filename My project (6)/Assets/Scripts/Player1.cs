using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //поля
    
    [SerializeField] private float speed;//открытый для редакции в unity
    [SerializeField] private LayerMask playerLayer;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private bool player;
    private BoxCollider2D boxCollider;




    private void Awake()
    {
        //эти две строки помогут получить ссылки для нашего rigidbody и animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
       
    }

    private void Update()
    {
        //писать через if else - моветон 
        //пожтому , богданчик, будем использовать get axis
        //в input manager я настроил horizontal И horizontal2 для двух игроков как раз на одной клаве

        //управление стрелками
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //поворот игрока при движении вправо/влево

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(6, 6, 6);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-6, 6, 6);

        //прыжок
        if (Input.GetKey(KeyCode.UpArrow) && grounded && player && !isPlayerAbovePlayer())
            Jump();

        //параметры анимации
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

       // print(isPlayerAbovePlayer());
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
        player = false;
       

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Player")
        {
            grounded = true;
            player = true;

        }
    }

    private bool isPlayerAbovePlayer()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.1f, playerLayer);
        return raycastHit.collider != null;
    }


}
