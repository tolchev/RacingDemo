using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class MovementCreator
{
    private volatile bool isSuccess = true;

    class InternalMovementTimer : IMovementTimer
    {
        float time;

        public float GetTime()
        {
            return time;
        }

        public void Next()
        {
            time += 0.2f;
        }
    }

    public Tuple<float[], float[]> Create(float distance, float differenceDistance, float time, float differenceTime, int pointCount)
    {
        int i = 0;

        while (true)
        {
            Debug.Log(i);
            if (i++ > 10000)
            {
                Debug.LogError("Failed");
                throw new Exception();
            }

            Debug.LogWarning(i);

            float[] subDistances = RangeDelimiter.Get(distance, differenceDistance, pointCount);
            //float[] subTimes = RangeDelimiter.Get(time, differenceTime, pointCount);
            float[] subTimes = Enumerable.Range(0, pointCount + 1).Select(i => i * time / pointCount).ToArray();

            float prevDistance = -1;
            var timer = new InternalMovementTimer();
            Movement movement = new Movement(timer);
            movement.DistanceChanged += delegate (object sender, MovementParametersArgs args)
            {
                isSuccess = args.Distance > prevDistance && args.Velocity >= 0;
            };
            
            IEnumerator enumerator = movement.Running(subDistances, subTimes);
            while (isSuccess && enumerator.MoveNext())
                timer.Next();

            if (isSuccess)
            {
                return Tuple.Create(subDistances, subTimes);
            }
        }
    }
}