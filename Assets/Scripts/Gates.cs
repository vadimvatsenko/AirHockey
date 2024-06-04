using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] bool isEnemyGate = true;
    ParticleSystem fire;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<HockeyPuck>())
        {
            //fire.Play();
            Events.InvokeChangeScore(isEnemyGate);
            Events.InvokeResetGameAfterGoal();
        }
    }
}