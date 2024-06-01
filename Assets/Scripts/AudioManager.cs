using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip PuckCollision;
    [SerializeField] AudioClip Goal;
    [SerializeField] AudioClip WallCollision;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    private void Update()
    {
        audioSource.volume = PlayerPrefs.GetFloat(StaticMenuFields.Value);
    }

    public void PlayPuchOnCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(Goal);
    }

    public void PlayWallSound() 
    { 
        audioSource.PlayOneShot(WallCollision);
    }
}
