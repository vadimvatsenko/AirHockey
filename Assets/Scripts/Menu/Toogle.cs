using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Toogle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private GameObject sliderParent;
    private TextMeshProUGUI sliderCounter;
    RectTransform transformSiderParent;
    RectTransform transformChildParent;

    private bool isToggle = false;
    
    private void Start()
    {
        sliderParent = transform.parent.gameObject;
        sliderCounter = transform.parent.GetChild(0).GetComponent<TextMeshProUGUI>();
        transformSiderParent = transform.parent.GetComponent<RectTransform>();
        transformChildParent = this.transform.GetComponent<RectTransform>();
    }
    private void Update()
    {                         
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // получаем мировые координаты
        Vector3 localPos = transformSiderParent.InverseTransformPoint(worldPos); // InverseTransformPoint преобразовывает мировые координаты в координаты родителя

        float leftStoper = (transformSiderParent.rect.size.x / -2) + (transformChildParent.rect.size.x / 2);
        float rightStoper = (transformSiderParent.rect.size.x / 2) - (transformChildParent.rect.size.x / 2);

        float clampedX = Mathf.Clamp(localPos.x, leftStoper, rightStoper);
        
        if (isToggle)
        {
            this.transform.localPosition = new Vector3(clampedX, this.transform.position.y);
            float percent = Mathf.InverseLerp(leftStoper, rightStoper, clampedX);
            sliderCounter.text = percent.ToString("0" + "%");
        }
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
