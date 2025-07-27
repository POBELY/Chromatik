using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    public enum Filter
    {
        RED,
        GREEN,
        BLUE,
    }

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

    public static Color MonoFilter(float mainCanal, float otherCanal, float otherCanal2)
    {
        float r = mainCanal;
        float g = otherCanal;
        float b = otherCanal2;

        float mean = (r + g + b) / 3.0f;
        float mean2 = (g + b) / 2.0f;

        Color result = new();
        result.g = Mathf.Min(mean, mean2);
        result.b = result.g;
        result.r = Mathf.Max(r, mean);

        return result;
    }

    public static Color MonoFilter(Color color, Filter filter)
    {
        return filter switch {
            Filter.RED => MonoFilter(color.r, color.g, color.b),
            Filter.GREEN => MonoFilter(color.g, color.r, color.b),
            Filter.BLUE => MonoFilter(color.b, color.g, color.r),
        };
    }

    public static void Main() {
        Color filteredColor = MonoFilter(Color.green, Filter.GREEN);
    }

}
