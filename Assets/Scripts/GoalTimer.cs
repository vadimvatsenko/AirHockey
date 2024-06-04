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
        startTimer = sec;
        this.gameObject.SetActive(true);

        textMeshProComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerToGo());

    }

    IEnumerator TimerToGo()
    {
        
        while (true)
        {
            startTimer--;
            textMeshProComponent.text = startTimer.ToString();
            yield return new WaitForSeconds(1);

            if (startTimer <= 0)
            {
                textMeshProComponent.text = "GO!";
                yield return new WaitForSeconds(1);
                this.gameObject.SetActive(false);
                //Events.InvokeEnableOrDisableGameObject();
                yield break;
            }
        }
    }



}
