using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    [SerializeField] GameObject Puck;
    protected override void Start()
    {
        base.Start();


    }


    new private void Update()
    {
        rb.transform.position = Vector3.MoveTowards(rb.transform.position, new Vector3(Puck.transform.position.x, rb.transform.position.y), 1f * Time.deltaTime);
    }
}
