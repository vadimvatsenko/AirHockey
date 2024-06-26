using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoalTimer : MonoBehaviour
{
    private TextMeshProUGUI textMeshProComponent;
    private int sec = 3;
    private int startTimer;

    private void Start()
    {
        this.gameObject.SetActive(true);
        Time.timeScale = 0;
        startTimer = sec;
        textMeshProComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerToGo());
        

    }

    IEnumerator TimerToGo()
    {
        
        while (true)
        {
            startTimer--;
            textMeshProComponent.text = startTimer.ToString();
            yield return new WaitForSecondsRealtime(1);

            if (startTimer <= 0)
            {
                textMeshProComponent.text = "GO!";
                yield return new WaitForSecondsRealtime(1);
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
                //Events.InvokeEnableOrDisableGameObject();
                yield break;
            }
        }
    }



}
