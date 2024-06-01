using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class StaticMenuFields
{
    public static string colorTextGradient1 { get; private set; } = "#FFE200FF";
    public static string colorTextGradient2 { get; private set; } = "#FF4400FF";

    private static int valuePercent = 100;
    public static string Value => "Value"; 
    public static int ValuePercent 
    {  
        get 
        { 
            return valuePercent; 
        } 

        private set
        {
            valuePercent = value;
        }
    }
}
