using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HockeyPuck : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] ParticleSystem effect;

    Rigidbody2D rb;
    private Vector2 prevPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //effect = GetComponentInChildren<ParticleSystem>();
    }

    private void Update()
    {
        prevPos = rb.velocity;
    }

    private void OnEnable()
    {
        Events.resetGameAfterGoal += HandleResetPuck;
    }

    private void OnDestroy()
    {
        Events.resetGameAfterGoal -= HandleResetPuck;
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Vector2 direction = this.transform.position - collision.transform.position;
        Vector2 force = prevPos - rb.position;

        effect.transform.position = collision.contacts[0].point;
        effect.Play();
        audioManager.PlayPuchOnCollision();

        if (collision.gameObject.GetComponent<Player>() || collision.gameObject.GetComponent<Enemy>())
        {
            rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        }
        else
        {
            
            Vector2 reflectedVector = Vector3.Reflect(prevPos.normalized, collision.contacts[0].normal); 
            rb.AddForce(reflectedVector.normalized * force, ForceMode2D.Impulse); // *force.magnitude           
        }



    }

    private void HandleResetPuck()
    {
        StartCoroutine(ResetPuck());
    }

    private IEnumerator ResetPuck()
    {       
        yield return new WaitForSeconds(3);
        rb.position = new Vector2(0, 0);
    }
}
