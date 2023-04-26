using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{

    //����

    [SerializeField] private float speed;//�������� ��� �������� � unity
    private Rigidbody2D body;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //��� �� ������ ��������
        //����� ��� horizontal2 � ����
       
        //����������� �� ������� a d
        body.velocity = new Vector2(Input.GetAxis("Horizontal2") * speed, body.velocity.y);

        //������
        if (Input.GetKey(KeyCode.W))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
