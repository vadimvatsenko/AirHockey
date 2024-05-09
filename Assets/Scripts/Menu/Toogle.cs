using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Toogle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject sliderParent;
    private TextMeshProUGUI sliderCounter;
    RectTransform transformSiderParent;
    RectTransform transformChildParent;
    RectTransform transformSliderFill;

    private Image sliderColor;

    private bool isToggle = false;
    
    private void Start()
    {
        sliderParent = transform.parent.gameObject;
        sliderCounter = transform.parent.GetChild(1).GetComponent<TextMeshProUGUI>();
        transformSiderParent = transform.parent.GetComponent<RectTransform>();
        transformChildParent = this.transform.GetComponent<RectTransform>();
        transformSliderFill = transform.parent.GetChild(0).GetComponent<RectTransform>();

        sliderColor = transform.parent.GetChild(0).GetComponent<Image>();
    }
    private void Update()
    {                         
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // получаем мировые координаты
        Vector3 localPos = transformSiderParent.InverseTransformPoint(worldPos); // InverseTransformPoint преобразовывает мировые координаты в координаты родителя (локальные координаты)

        float leftStoper = (transformSiderParent.rect.size.x / -2) + (transformChildParent.rect.size.x / 2);
        float rightStoper = (transformSiderParent.rect.size.x / 2) - (transformChildParent.rect.size.x / 2);
        float clampedX = Mathf.Clamp(localPos.x, leftStoper, rightStoper);

        if (isToggle)
        {
            this.transform.localPosition = new Vector3(clampedX, this.transform.position.y);

            float percent = Mathf.InverseLerp(leftStoper, rightStoper, clampedX); // InverseLerp - нормализует значение, от 0 до 1
            ChangeColorPercent(percent);
            transformSliderFill.sizeDelta = new Vector2(percent * 310f, transformSliderFill.sizeDelta.y);

            sliderCounter.text = percent.ToString("0" + "%");
        }
    }

    private void ChangeColorPercent(float perc)
    {
        sliderColor.color = new Color(255f, 0f, 0f, perc);
    }

    public void OnPointerDown(PointerEventData eventData)
    {           
        isToggle = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isToggle = false;
    }

}
