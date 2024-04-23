using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] TextMeshProUGUI Timer;
    [SerializeField] float StartTimer;

    private void Awake()
    {
        if(Instance != null)
        {
            DestroyImmediate(gameObject);
        }
        else 
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        StartTimer -= Time.deltaTime;
       
        Timer.text = StartTimer.ToString();

        Debug.Log(StartTimer / 60);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    private void NewGame()
    {
       
    }

    
}
