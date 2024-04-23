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
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // конвертация в Vector3 позиции мышки в общем пространстве

        float clampedX = Mathf.Clamp(mousePosition.x, leftBoardStopper, rightBoardStopper); // высчитываем ограничение по X
        float clampedY = Mathf.Clamp(mousePosition.y, bottomBoardStopper, topBoardStopper); // высчитываем ограничение по Y

        rb.position = new Vector3(clampedX, clampedY, 0); // позиция игрока, только через Rigidbody

        //this.transform.position = new Vector3(clampedX, clampedY, 0);  // записываем позицию игрока
        //prevPos = this.transform.position; // записываем предыдущую позицию игрока
        
    }

    // таймер, от 2 минут UI, бортики
}
