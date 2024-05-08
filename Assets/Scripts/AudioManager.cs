using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip PuckCollision;
    [SerializeField] AudioClip Goal;

    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayPuchOnCollision()
    {
        audioSource.PlayOneShot(PuckCollision);
    }

    public void PlayGoalSound()
    {
        audioSource.PlayOneShot(Goal);
    }
}
