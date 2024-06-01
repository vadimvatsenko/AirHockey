using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] protected Transform Board;

    protected BoardStopper unitBorderStopper;
    protected Rigidbody2D rb;
    protected Vector2 prevPos; // предыдущая позиция игрока, получаем в update
    protected Vector2 unitSize;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        unitSize = this.gameObject.GetComponent<Collider2D>().bounds.size;
        // left, right, top, bottom
        unitBorderStopper = new BoardStopper(Board.GetChild(0).position.x + (unitSize.x / 2) + (Board.GetChild(0).GetComponent<Collider2D>().bounds.size.x / 2), 
                                             Board.GetChild(1).position.x - (unitSize.x / 2) - (Board.GetChild(1).GetComponent<Collider2D>().bounds.size.x / 2),
                                             Board.GetChild(4).position.y - (unitSize.y / 2),
                                             Board.GetChild(3).position.y + (unitSize.y / 2) + (Board.GetChild(3).GetChild(0).GetComponent<Collider2D>().bounds.size.y / 2)) ;     
                                             //Board.GetChild(2).position.y - (unitSize.y / 2) - (Board.GetChild(2).GetChild(0).GetComponent<Collider2D>().bounds.size.y / 2));
    }

    private void Update()
    {
        prevPos = rb.velocity; // velocity - направление        
    }

}



