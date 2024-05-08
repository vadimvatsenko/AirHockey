using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI enemyScoreUI;
    private TextMeshProUGUI playerScoreUI;

    private int playerScore = 0;
    private int enemyScore = 0;
 
    private void OnEnable()
    {
        Events.changeScore += ChangeScore;
    }
    private void OnDisable()
    {
        Events.changeScore -= ChangeScore;
    }
    private void Start()
    {
        enemyScoreUI = transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>();
        playerScoreUI = transform.GetChild(transform.childCount - 1).GetComponentInChildren<TextMeshProUGUI>();       
    }

    private void ChangeScore(bool isEnemyGate)
    {
        if(isEnemyGate)
        {            
            playerScore++;           
            playerScoreUI.text = playerScore.ToString();
        }
        else
        {
            enemyScore++;            
            enemyScoreUI.text = enemyScore.ToString();
        }
    }
}
