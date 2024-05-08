using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private int sec = 0;
    private int min = 2;
    private TextMeshProUGUI textMeshProComponent;

    void Start()
    {
        textMeshProComponent = GetComponent<TextMeshProUGUI>();
        StartCoroutine(TimerFlow());
    }

    IEnumerator TimerFlow() // IEnumerator - интерфейс
    {
        /*sec++;
        sec = sec % 59;*/
        
        while (true)
        {
            if (sec == 0)
            {
                if (min == 0)
                {
                    StopCoroutine(TimerFlow());
                    yield break;
                }
                min--;
                sec = 59;
            }
            else
            {
                sec--;
            }

            textMeshProComponent.text = min.ToString("00") + ":" + sec.ToString("00");
            yield return new WaitForSeconds(1);
        }
    }
}
