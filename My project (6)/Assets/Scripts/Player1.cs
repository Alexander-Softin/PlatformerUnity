using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
{
    //����
    
    [SerializeField] private float speed;//�������� ��� �������� � unity
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;


    private void Awake()
    {
        //��� ��� ������ ������� �������� ������ ��� ������ rigidbody � animator 
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //������ ����� if else - ������� 
        //������� , ���������, ����� ������������ get axis
        //� input manager � �������� horizontal � horizontal2 ��� ���� ������� ��� ��� �� ����� �����

        //���������� ���������
        float horizontalInput = Input.GetAxis("Horizontal");

        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //������� ������ ��� �������� ������/�����

        if (horizontalInput > 0.01f)
            transform.localScale = new Vector3(6, 6, 6);
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-6, 6, 6);

        //������
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
            Jump();

        //��������� ��������
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed);
        anim.SetTrigger("jump");
        grounded = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            grounded = true;
    }
}
