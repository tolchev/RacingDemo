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

    public IEnumerator Running(MovementData[] datas)
    {
        float t0 = movementTimer.GetTime();

        for (int i = 0; i < datas.Length - 1; i++)
        {
            float v0 = (datas[i + 1].Distance - datas[i].Distance) / (datas[i + 1].Time - datas[i].Time);

            while (movementTimer.GetTime() - t0 < datas[i + 1].Time)
            {
                float curT = movementTimer.GetTime() - t0;
                float curSubT = curT - datas[i].Time;
                float curSubS = v0 * curSubT;
                DistanceChanged(this, new MovementParametersArgs(distance: curSubS + datas[i].Distance, time: curT));
                yield return null;
            }
        }
    }
}
