using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Utils
{
    public static bool inRange(float val, float min, float max)
    {
        return (val > min && val < max);
    }
}