using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HockeyPuck : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    ParticleSystem effect;

    Rigidbody2D rb;
    private Vector2 prevPos;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        effect = GetComponentInChildren<ParticleSystem>();
        //this.gameObject.SetActive(false);
    }

    private void Update()
    {
        prevPos = rb.velocity;
    }

    private void OnEnable()
    {
        Events.resetGameAfterGoal += HandleResetPuck;
        Events.enableOrDisableGameObject += DisableOrEnablePuck;
    }

    private void OnDestroy()
    {
        Events.resetGameAfterGoal -= HandleResetPuck;
        Events.enableOrDisableGameObject += DisableOrEnablePuck;
    }


    private void OnCollisionEnter2D(Collision2D collision) 
    {

        Vector2 direction = this.transform.position - collision.transform.position;
        Vector2 force = prevPos - rb.position;

        if (collision.gameObject.GetComponent<Player>() || collision.gameObject.GetComponent<Enemy>())
        {
            rb.AddForce(direction.normalized * force, ForceMode2D.Impulse);
        }
        else
        {
            Vector2 reflectedVector = Vector3.Reflect(prevPos.normalized, collision.contacts[0].normal);
            rb.AddForce(reflectedVector.normalized * force, ForceMode2D.Impulse); // *force.magnitude
        }
        audioManager.PlayPuchOnCollision();
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

    private void DisableOrEnablePuck()
    {
        bool active = this.gameObject.activeSelf;
        this.gameObject.SetActive(!active);
    }
}
