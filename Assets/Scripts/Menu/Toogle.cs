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
    RectTransform transformSliderFill1;
    RectTransform transformSliderFill2;

    private Image sliderColor;
    private float sliderWidth;

    private bool isToggle = false;


    
    private void Start()
    {
        sliderParent = transform.parent.gameObject;
        sliderCounter = transform.parent.GetChild(2).GetComponent<TextMeshProUGUI>();
        transformSiderParent = transform.parent.GetComponent<RectTransform>();
        transformChildParent = this.transform.GetComponent<RectTransform>();
        transformSliderFill1 = transform.parent.GetChild(0).GetComponent<RectTransform>();
        transformSliderFill2 = transform.parent.GetChild(1).GetComponent<RectTransform>();

        sliderColor = transform.parent.GetChild(0).GetComponent<Image>();
        sliderWidth = transformSliderFill1.sizeDelta.x;
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
            ChangeColorPercent(percent, new Color(255f, 0f, 0f, percent));
            //transformSliderFill1.sizeDelta = new Vector2(percent * sliderWidth, transformSliderFill1.sizeDelta.y);

            transformSliderFill1.GetComponent<Image>().fillAmount = percent;

            transformSliderFill2.GetComponent<Image>().fillAmount = 1 - percent;

            transformSliderFill2.GetComponent<Image>().color = new Color(0f, 0f, 255f, 1 - percent);

            sliderCounter.text = percent.ToString("0" + "%");

            PlayerPrefs.SetFloat(StaticMenuFields.Value, percent);
        }
    }

    private void ChangeColorPercent(float perc, Color color)
    {
        sliderColor.color = color;
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
