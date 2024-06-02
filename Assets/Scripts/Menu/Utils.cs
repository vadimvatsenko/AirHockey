using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Color HexToRGB(string hex)
    {
        if (ColorUtility.TryParseHtmlString(hex, out Color color))
        {
            return color;
        }
        else
        {
            Debug.LogWarning("Неверный формат HEX.");
            return Color.black; // Возвращаем черный цвет в случае ошибки
        }
    }
}
