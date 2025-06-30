using System.Linq;

public static class MovementCreator
{
    public static MovementData[] Create(float distance, float differenceDistance, float time, float differenceTime, int pointCount)
    {
        float[] subDistances = RangeDelimiter.Get(distance, differenceDistance, pointCount);
        float v0 = distance / time;
        float t0 = (subDistances[1] - subDistances[0]) / v0;
        float[] subTimes = new float[pointCount + 1];
        float[] restSubTimes = RangeDelimiter.Get(time - t0, differenceTime, pointCount - 1);
        for (int i = 1; i <= pointCount; i++)
        {
            subTimes[i] = restSubTimes[i - 1] + t0;
        }

        return Enumerable.Range(0, pointCount + 1)
            .Select(i => new MovementData(subDistances[i], subTimes[i]))
            .ToArray();
    }
}