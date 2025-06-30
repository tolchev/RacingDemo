using UnityEngine;

public static class RangeDelimiter
{
    public static float[] Get(float value, float difference, int count)
    {
        float[] lines = new float[count + 1];
        lines[0] = 0;
        lines[count] = value;
        for (int i = 1; i < count; i++)
        {
            lines[i] = value / count * i;
        }

        for (int i = 1; i < count - 1; i++)
        {
            var delta = (float)System.Math.Round(Random.Range(-difference / 2, difference / 2), 2);
            lines[i] += delta;
            lines[i + 1] -= delta;
        }

        return lines;
    }
}
