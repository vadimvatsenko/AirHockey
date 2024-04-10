using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject leftBoard; // ����� ������
    [SerializeField] private GameObject rightBoard; // ������ ������
    [SerializeField] private GameObject topBoard; // ������� ������
    [SerializeField] private GameObject bottomBoard; // ������ ������

    [SerializeField] private GameObject field; // ����

    private Vector2 leftRight; // ������������ ����� � ������ �������
    private Vector2 TopBottom; // ������������ ������� � ������ �������

    Vector3 prevPos; // ���������� ������� ������, �������� � update

    private void Start()
    {        
        leftRight = 
            new Vector2(leftBoard.transform.position.x + (this.transform.localScale.x / 2) + (leftBoard.transform.localScale.x / 2), 
            rightBoard.transform.position.x - (this.transform.localScale.x / 2) - (rightBoard.transform.localScale.x / 2));
        // x = ���������� ������ ����� �� x + ����� ������ �� � / 2 + ����� ������ ����� /2
        // y = ���������� ������� ����� �� x - ����� ������ �� � / 2 - ����� ������� ����� /2
        TopBottom = 
            new Vector2(field.transform.position.y - this.transform.localScale.y / 2, 
            (field.transform.position.y - field.transform.localScale.y / 2) + (this.transform.localScale.y / 2) + bottomBoard.transform.localScale.y);
        // x = ���������� �������� ����(��� ��� ��������� ���������� � ��������) - ����� ������ �� � / 2
        // y = (���������� �������� ���� - ����� ���� / 2) + ����� ������ / 2 + ������ ���� �� y

    }

    private void Update()
    {
               
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ����������� � Vector3 ������� ����� � ����� ������������

        float clampedX = Mathf.Clamp(mousePosition.x, leftRight.x, leftRight.y); // ����������� ����������� �� X
        float clampedY = Mathf.Clamp(mousePosition.y, TopBottom.y, TopBottom.x); // ����������� ����������� �� Y

        this.transform.position = new Vector3(clampedX, clampedY, 0);  // ���������� ������� ������
        
        prevPos = this.transform.position; // ���������� ���������� ������� ������

    }

    private void OnCollisionEnter2D(Collision2D collision) // OnCollisionEnter2D - ������������, collision - ������ � ������� �����������
    {
        Vector2 direction =  (collision.transform.position - this.transform.position).normalized;
        // collision - ���������� ����� �����, �������� ������� ����� �� ������� ������ � ������������� �������
        Vector3 force = (this.transform.position - prevPos);
        // force - ��������� ������� ������� ������ - ����������
        collision.rigidbody.AddForce(direction * force.magnitude * 100, ForceMode2D.Impulse);
        // AddForce - �������� ���������
    }
}
