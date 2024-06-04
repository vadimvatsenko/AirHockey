using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] Rigidbody2D Puck;
    [SerializeField] float speed = 10f;
    private Vector2 startPosition;
    private Vector2 targetPosition;
    private float movemetSpeed;

    protected override void Start()
    {
        base.Start();
        startPosition = rb.position;

        unitBorderStopper = new BoardStopper(Left.position.x + this.GetComponent<Collider2D>().bounds.size.x / 2,
                                            Right.position.x - this.GetComponent<Collider2D>().bounds.size.x / 2,
                                            Top.position.y + this.GetComponent<Collider2D>().bounds.size.x / 2,
                                            Center.position.y);
    }

    private void FixedUpdate()
    {   
        if(Puck.position.y < 0)
        {
            movemetSpeed = speed * Random.Range(0.1f, 0.3f);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, unitBorderStopper.Left, unitBorderStopper.Right), startPosition.y );
            Debug.Log(1);
        }
        
        else 
        {
            
            movemetSpeed = Random.Range(speed * 0.4f, speed);
            targetPosition = new Vector2(Mathf.Clamp(Puck.position.x, unitBorderStopper.Left, unitBorderStopper.Right), Mathf.Clamp(Puck.position.y, unitBorderStopper.Bottom, unitBorderStopper.Top));
            Debug.Log(3);
        }

        rb.MovePosition(Vector2.MoveTowards(rb.position, targetPosition, movemetSpeed * Time.fixedDeltaTime));

        if (Puck.position.y > unitBorderStopper.Top) 
        {
            rb.MovePosition(startPosition);
        }
    }
}
