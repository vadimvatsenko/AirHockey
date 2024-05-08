using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gates : MonoBehaviour
{
    [SerializeField] bool isEnemyGate = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.GetComponent<HockeyPuck>())
        {
            Events.InvokeChangeScore(isEnemyGate);
            Events.InvokeResetGameAfterGoal();
        }
    }
}