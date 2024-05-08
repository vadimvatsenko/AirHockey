using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slider : MonoBehaviour
{
    private GameObject sliderParent;
    private void Start()
    {
        sliderParent = transform.parent.gameObject;
    }
    private void Update()
    {
        RectTransform transformSiderParent = transform.parent.GetComponent<RectTransform>();
        RectTransform transformChildParent = this.transform.GetComponent<RectTransform>();

        float leftStoper = (transformSiderParent.rect.size.x / -2) + (transformChildParent.rect.size.x / 2);
        float rightStoper = (transformSiderParent.rect.size.x / 2) - (transformChildParent.rect.size.x / 2);

        //float convertMousePosition = 

        float clampedX = Mathf.Clamp(Input.mousePosition.x, leftStoper, rightStoper);
     
        this.transform.localPosition = new Vector3(clampedX, this.transform.position.y);

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        Debug.Log(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was not Clicked.");
    }




}
