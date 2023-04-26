using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    //поля

    [SerializeField] private float speed;//открытый для редакции в unity
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //как ты можешь заметить
        //здесь уже horizontal2 и перс
       
        //управляется на клавиши a d
        body.velocity = new Vector2(Input.GetAxis("Horizontal2") * speed, body.velocity.y);

        //прыжок
        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
