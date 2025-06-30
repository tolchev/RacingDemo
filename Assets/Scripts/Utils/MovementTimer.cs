using UnityEngine;

public class MovementTimer : IMovementTimer
{
    private static MovementTimer instance;

    private MovementTimer() { }

    public static MovementTimer Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new MovementTimer();
            }
            return instance;
        }
    }

    #region IMovementTimer

    public float GetTime()
    {
        return Time.time;
    }

    #endregion
}