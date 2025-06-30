using System;

public class MovementParametersArgs : EventArgs
{
    public MovementParametersArgs(float distance, float velocity, float time)
    {
        Distance = distance;
        Velocity = velocity;
        Time = time;
    }

    public float Distance { get; }
    public float Velocity { get; }
    public float Time { get; }
}
