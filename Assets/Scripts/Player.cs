using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private GameObject leftBoard; // левый бортик
    [SerializeField] private GameObject rightBoard; // правый бортик
    [SerializeField] private GameObject topBoard; // верхний бортик
    [SerializeField] private GameObject bottomBoard; // нижний бортик

    [SerializeField] private GameObject field; // поле

    private Vector2 leftRight; // ограничители левой и правой стороны
    private Vector2 TopBottom; // ограничители верхней и нижний границы

    Vector3 prevPos; // предыдущая позиция игрока, получаем в update

    private void Start()
    {        
        leftRight = 
            new Vector2(leftBoard.transform.position.x + (this.transform.localScale.x / 2) + (leftBoard.transform.localScale.x / 2), 
            rightBoard.transform.position.x - (this.transform.localScale.x / 2) - (rightBoard.transform.localScale.x / 2));
        // x = координаты левого борта по x + скейл игрока по х / 2 + скейл левого борта /2
        // y = координаты правого борта по x - скейл игрока по х / 2 - скейл правого борта /2
        TopBottom = 
            new Vector2(field.transform.position.y - this.transform.localScale.y / 2, 
            (field.transform.position.y - field.transform.localScale.y / 2) + (this.transform.localScale.y / 2) + bottomBoard.transform.localScale.y);
        // x = координаты серидины поля(так как кординаты начинаются с середины) - скейл игрока по х / 2
        // y = (координаты серидины поля - скейл поля / 2) + скейл игрока / 2 + нижний борд по y

    }

    private void Update()
    {
               
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); // конвертация в Vector3 позиции мышки в общем пространстве

        float clampedX = Mathf.Clamp(mousePosition.x, leftRight.x, leftRight.y); // высчитываем ограничение по X
        float clampedY = Mathf.Clamp(mousePosition.y, TopBottom.y, TopBottom.x); // высчитываем ограничение по Y

        this.transform.position = new Vector3(clampedX, clampedY, 0);  // записываем позицию игрока
        
        prevPos = this.transform.position; // записываем предыдущую позицию игрока

    }

    private void OnCollisionEnter2D(Collision2D collision) // OnCollisionEnter2D - столкновение, collision - объект с которым столкнулись
    {
        Vector2 direction =  (collision.transform.position - this.transform.position).normalized;
        // collision - траектория полёта шайбы, отнимаем позицию шайбы от позиции игрока с нормализацией вектора
        Vector3 force = (this.transform.position - prevPos);
        // force - ускорение текущая позиция игрока - предыдущая
        collision.rigidbody.AddForce(direction * force.magnitude * 100, ForceMode2D.Impulse);
        // AddForce - добавить ускорение
    }
}
