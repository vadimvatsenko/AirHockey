using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BoardStopper
{
    public float Top { get; private set; }
    public float Bottom { get; private set; }
    public float Left { get; private set; }
    public float Right { get; private set; }

    public BoardStopper(float left, float right, float top, float bottom)
    {
        Top = top;
        Bottom = bottom;
        Left = left;
        Right = right;
    }
}
