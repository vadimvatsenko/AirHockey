using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Unit
{
   /* Rigidbody2D rb;*/
    protected override void Start()
    {
        base.Start();
       /* rb = GetComponent<Rigidbody2D>();*/
    }

    new private void Update()
    {   
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ����������� � Vector3 ������� ����� � ����� ������������

        float clampedX = Mathf.Clamp(mousePosition.x, leftBoardStopper, rightBoardStopper); // ����������� ����������� �� X
        float clampedY = Mathf.Clamp(mousePosition.y, bottomBoardStopper, topBoardStopper); // ����������� ����������� �� Y

        rb.position = new Vector3(clampedX, clampedY, 0); // ������� ������, ������ ����� Rigidbody

        //this.transform.position = new Vector3(clampedX, clampedY, 0);  // ���������� ������� ������
        //prevPos = this.transform.position; // ���������� ���������� ������� ������
        
    }

    // ������, �� 2 ����� UI, �������
}
