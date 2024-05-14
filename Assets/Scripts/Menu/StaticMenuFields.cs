using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticMenuFields
{
    private static int valuePercent = 100;

    public static string Value => "Value"; 

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
