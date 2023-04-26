using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : MonoBehaviour
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
        //������ ����� if else - ������� 
        //������� , ���������, ����� ������������ get axis
        //� input manager � �������� horizontal � horizontal2 ��� ���� ������� ��� ��� �� ����� �����

        //���������� ���������
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //������
        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
    }
}
