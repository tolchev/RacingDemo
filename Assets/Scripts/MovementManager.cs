using System;
using System.Collections;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    private Movement movement;

    public MovementManager()
    {
        movement = new Movement(MovementTimer.Instance);
    }

    public event EventHandler<MovementParametersArgs> DistanceChanged
    {
        add
        {
            movement.DistanceChanged += value;
        }
        remove
        {
            movement.DistanceChanged -= value;
        }
    }

    public IEnumerator Running(float[] subDistances, float[] subTimes)
    {
        return movement.Running(subDistances, subTimes);
    }
}
