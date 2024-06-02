using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Transform Stopper;

    protected Transform Left;
    protected Transform Right;
    protected Transform Top;
    protected Transform Bottom;
    protected Transform Center;

    protected BoardStopper unitBorderStopper;
    protected Rigidbody2D rb;
    protected Vector2 prevPos; // предыдущая позиция игрока, получаем в update
    protected Vector2 unitSize;

    protected virtual void Start()
    {
        Left = Stopper.GetChild(0).GetComponent<Transform>();
        Right = Stopper.GetChild(1).GetComponent<Transform>();
        Top = Stopper.GetChild(2).GetComponent<Transform>();
        Bottom = Stopper.GetChild(3).GetComponent<Transform>();
        Center = Stopper.GetChild(4).GetComponent<Transform>();

        rb = GetComponent<Rigidbody2D>();
        unitSize = this.gameObject.GetComponent<Collider2D>().bounds.size;

        unitBorderStopper = new BoardStopper(Left.position.x + this.GetComponent<Collider2D>().bounds.size.x / 2,
                                            Right.position.x - this.GetComponent<Collider2D>().bounds.size.x / 2,
                                            Center.position.x,
                                            -12.65f + this.GetComponent<Collider2D>().bounds.size.x / 2);
    }

    private void Update()
    {
        prevPos = rb.velocity; // velocity - направление        
    }

}



