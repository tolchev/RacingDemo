using System;
using System.Collections;

public class Movement
{
    private readonly IMovementTimer movementTimer;

    public event EventHandler<MovementParametersArgs> DistanceChanged;

    public Movement(IMovementTimer movementTimer)
    {
        this.movementTimer = movementTimer;
    }

    public IEnumerator Running(float[] subDistances, float[] subTimes)
    {
        float t0 = movementTimer.GetTime();
        float v0 = 0;
        float a = 0;

        for (int i = 0; i < subTimes.Length - 1; i++)
        {
            if (i > 0)
            {
                v0 = CalcVelocity(subDistances[i] - subDistances[i - 1], v0, a);
            }

            a = CalcAcceleration(subDistances[i + 1] - subDistances[i], v0, subTimes[i + 1] - subTimes[i]);

            while (movementTimer.GetTime() - t0 < subTimes[i + 1])
            {
                float curT = movementTimer.GetTime() - t0;
                float curSubT = curT - subTimes[i];
                float curSubS = v0 * curSubT + a * curSubT * curSubT / 2;
                DistanceChanged(this, new MovementParametersArgs(distance: curSubS + subDistances[i], velocity: v0 + a * curSubT, time: curT));
                yield return null;
            }
        }
    }

    private float CalcAcceleration(float s, float v0, float t)
    {
        return 2 * (s - v0 * t) / (t * t);
    }

    private float CalcVelocity(float s, float v0, float a)
    {
        return UnityEngine.Mathf.Sqrt(2 * s * a + v0 * v0);
    }
}
