using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : Unit, IPointerDownHandler, IPointerUpHandler
{
    private bool isPlayer = false;
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {   
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ����������� � Vector3 ������� ����� � ����� ������������
        Vector3 locPos = Stopper.InverseTransformPoint(mousePosition);

        float clampedX = Mathf.Clamp(locPos.x, unitBorderStopper.Left, unitBorderStopper.Right); // ����������� ����������� �� X
        float clampedY = Mathf.Clamp(locPos.y, unitBorderStopper.Bottom, unitBorderStopper.Top); // ����������� ����������� �� Y

        rb.MovePosition(new Vector3(clampedX, clampedY, 0)); // ������� ������, ������ ����� Rigidbody//

        if (isPlayer)
        {
            Debug.Log(isPlayer);
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(eventData);
        isPlayer = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPlayer = false;
    }


}
