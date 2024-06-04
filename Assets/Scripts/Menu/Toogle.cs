using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Toogle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler // интерфейсы для отслеживание нажатия по объекту
{
    [SerializeField] private GameObject filledBG1;
    [SerializeField] private GameObject filledBG2;
    [SerializeField] private GameObject volume;
    [SerializeField] private GameObject gear;

    private RectTransform mainBGRectTransform;

    private bool isToggle = false;
    
    private void Start()
    {
        mainBGRectTransform = GetComponent<RectTransform>();
    }
    private void Update()
    {
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 localPos = mainBGRectTransform.InverseTransformPoint(worldPos); // мировые координаты в локальные

        float leftStoper = (mainBGRectTransform.rect.size.x / -2) + (gear.gameObject.GetComponent<RectTransform>().rect.size.x / 2);
        float rightStoper = (mainBGRectTransform.rect.size.x / 2) - (gear.gameObject.GetComponent<RectTransform>().rect.size.x / 2);
        float clampedX = Mathf.Clamp(localPos.x, leftStoper, rightStoper);

        if (isToggle)
        {
            float percent = Mathf.InverseLerp(leftStoper, rightStoper, clampedX); // InverseLerp - нормализует значение, от 0 до 1*/

            gear.transform.localPosition = new Vector3(clampedX, gear.transform.localPosition.y, 0);
            gear.transform.localRotation = Quaternion.Euler(0f, 0f, -percent * 360f); //Quaternion.Euler - создан для ротации фигуры

            filledBG1.GetComponent<Image>().fillAmount = percent;
            filledBG1.GetComponent<Image>().color = Color.Lerp(Utils.HexToRGB(StaticMenuFields.colorTextGradient1), Utils.HexToRGB(StaticMenuFields.colorTextGradient2), percent);

            volume.GetComponent<TextMeshProUGUI>().text = percent.ToString("0" + "%");

            volume.GetComponent<TextMeshProUGUI>().color = Color.Lerp(Utils.HexToRGB(StaticMenuFields.colorTextGradient1), Utils.HexToRGB(StaticMenuFields.colorTextGradient2), percent);

            PlayerPrefs.SetFloat(StaticMenuFields.Value, percent);
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
