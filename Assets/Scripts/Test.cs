using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public static Color RedFilter(Color input) {
        float r = input.r;
        float g = input.g;
        float b = input.b;

        float mean = (r + g + b) / 3.0f;
        float mean2 = (g + b) / 2.0f;

        input.g = Mathf.Min(mean, mean2);
        input.b = input.g;
        input.r = Mathf.Max(input.r, mean);

        return input;
    }
}
