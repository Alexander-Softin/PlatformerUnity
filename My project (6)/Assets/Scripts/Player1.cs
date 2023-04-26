using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
        //писать через if else - моветон 
        //пожтому , богданчик, будем использовать get axis
        //в input manager я настроил horizontal И horizontal2 для двух игроков как раз на одной клаве

        //управление стрелками
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //прыжок
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
