using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] Rigidbody2D Puck;
    [SerializeField] float speed = 2.5f;
    private Vector2 startPosition;
    private Vector2 targetPosition;

    protected override void Start()
    {
        base.Start();
        startPosition = rb.position;

        unitBorderStopper = new BoardStopper(Board.GetChild(0).position.x + (unitSize.x / 2) + (Board.GetChild(0).GetComponent<Collider2D>().bounds.size.x / 2),
                                             Board.GetChild(1).position.x - (unitSize.x / 2) - (Board.GetChild(1).GetComponent<Collider2D>().bounds.size.x / 2),
                                             Board.GetChild(2).position.y - (unitSize.y / 2) - (Board.GetChild(2).GetChild(0).GetComponent<Collider2D>().bounds.size.y / 2),
                                             Board.GetChild(4).position.y - (unitSize.y / 2));
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float movemetSpeed;
        
        if(Puck.position.y < unitBorderStopper.Bottom)
        {
            movemetSpeed = speed * Random.Range(0.1f, 0.3f);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, unitBorderStopper.Left, unitBorderStopper.Right), startPosition.y );           
        }
        else
        {
            movemetSpeed = Random.Range(speed * 0.4f, speed);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, unitBorderStopper.Left, unitBorderStopper.Right), Mathf.Clamp(Puck.position.y, unitBorderStopper.Bottom, unitBorderStopper.Top));
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movemetSpeed * Time.fixedDeltaTime));
    }
}
