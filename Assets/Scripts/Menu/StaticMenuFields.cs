using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMenuFields : MonoBehaviour
{
    private static int valuePercent = 100;

    public static int ValuePercent 
    {  
        get 
        { return valuePercent; 
        } 

        private set
        {
            valuePercent = value;
        }
    }
}
