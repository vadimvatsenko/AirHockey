using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Unit
{
    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {   
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // ����������� � Vector3 ������� ����� � ����� ������������

        float clampedX = Mathf.Clamp(mousePosition.x, unitBorderStopper.Left, unitBorderStopper.Right); // ����������� ����������� �� X
        float clampedY = Mathf.Clamp(mousePosition.y, unitBorderStopper.Bottom, unitBorderStopper.Top); // ����������� ����������� �� Y

        rb.MovePosition(new Vector3(clampedX, clampedY, 0)); // ������� ������, ������ ����� Rigidbody
        
    }

    

    
}
