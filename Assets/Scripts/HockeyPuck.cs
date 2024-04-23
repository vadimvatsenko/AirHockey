using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyPuck : Unit
{
    

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Vector2 direction = (rb.position - collision.rigidbody.position);
        Vector2 force = prevPos - rb.position;

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            rb.AddForce(direction * force.magnitude, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 reflectedVector = Vector3.Reflect(prevPos, collision.contacts[0].normal); 
            rb.AddForce(reflectedVector, ForceMode2D.Impulse);
        }
    }
}
