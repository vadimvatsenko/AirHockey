using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Events : MonoBehaviour
{
    public delegate void ChangeScore(bool isEnemyGate);
    public static event ChangeScore? changeScore;

    public delegate void ResetGameAfterGoal();
    public static event ResetGameAfterGoal? resetGameAfterGoal;

    public delegate void PlaySoundsEffect(AudioSource audioSource);
    public static event PlaySoundsEffect? playSoundsEffect;

    public static void InvokeChangeScore(bool isEnemyGate) // метод будет вызывать событие ChangeScore
    {
        changeScore?.Invoke(isEnemyGate);
    }

    public static void InvokeResetGameAfterGoal()
    {
        resetGameAfterGoal?.Invoke();
        
    }

    public static void InvokePlaySoundsEffect(AudioSource audioSource)
    {
        playSoundsEffect?.Invoke(audioSource);
    }
}
