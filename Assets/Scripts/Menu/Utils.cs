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
            Debug.LogWarning("�������� ������ HEX.");
            return Color.black; // ���������� ������ ���� � ������ ������
        }
    }
}
