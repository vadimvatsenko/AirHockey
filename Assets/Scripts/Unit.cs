using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected GameObject leftBoard; // ����� ������
    [SerializeField] protected GameObject rightBoard; // ������ ������
    [SerializeField] protected GameObject topBoard; // ������� ������
    [SerializeField] protected GameObject bottomBoard; // ������ ������
    [SerializeField] protected GameObject field; // ����

    protected Rigidbody2D rb;

    protected float leftBoardStopper;
    protected float rightBoardStopper;
    protected float topBoardStopper;
    protected float bottomBoardStopper;

    protected Vector2 prevPos; // ���������� ������� ������, �������� � update

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        leftBoardStopper = leftBoard.transform.position.x + (this.transform.localScale.x / 2) + (leftBoard.transform.localScale.x / 2);
        rightBoardStopper = rightBoard.transform.position.x - (this.transform.localScale.x / 2) - (rightBoard.transform.localScale.x / 2);
        topBoardStopper = field.transform.position.y - this.transform.localScale.y / 2;
        bottomBoardStopper = (field.transform.position.y - field.transform.localScale.y / 2) + (this.transform.localScale.y / 2) + bottomBoard.transform.localScale.y;

        /*topBoardStopper = topBoard.transform.position.y - (this.transform.localScale.y / 2) - (topBoard.transform.localScale.y / 2);
        bottomBoardStopper = bottomBoard.transform.position.y + (this.transform.localScale.y / 2) + (bottomBoard.transform.localScale.y / 2);*/
    }

    protected void Update()
    {
        prevPos = rb.velocity; // velocity - �����������
    }
}
