using System;

public class MovementParametersArgs : EventArgs
{
    public MovementParametersArgs(float distance, float time)
    {
        Distance = distance;
        Time = time;
    }

    public float Distance { get; }
    public float Time { get; }
}
