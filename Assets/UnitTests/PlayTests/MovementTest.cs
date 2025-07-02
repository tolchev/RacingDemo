using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

public class MovementTest
{
    private Movement movement;
    private float prevDistance;

    [SetUp]
    public void SetUp()
    {
        movement = new Movement(MovementTimer.Instance);
        prevDistance = -1;

        movement.DistanceChanged += CheckDistanceChanged;

        Time.timeScale = 10;
    }

    [TearDown]
    public void TearDown()
    {
        Time.timeScale = 1;
        movement.DistanceChanged -= CheckDistanceChanged;
    }

    [UnityTest]
    public IEnumerator Movement_Running_OneSubPath()
    {
        MovementData[] datas = new MovementData[]
        {
            new MovementData(0, 0),
            new MovementData(15, 5)
        };

        yield return movement.Running(datas);

        Assert.AreEqual(15, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator Movement_Running_TwoSubPath()
    {
        MovementData[] datas = new MovementData[]
        {
            new MovementData(0, 0),
            new MovementData(15, 5),
            new MovementData(25, 9)
        };

        yield return movement.Running(datas);

        Assert.AreEqual(25, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator Movement_Running_ThreeSubPath()
    {
        MovementData[] datas = new MovementData[]
        {
            new MovementData(0, 0),
            new MovementData(15, 5),
            new MovementData(25, 9),
            new MovementData(30, 10)
        };

        yield return movement.Running(datas);

        Assert.AreEqual(30, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator Movement_Running_FiveSubPath()
    {
        MovementData[] datas = new MovementData[]
        {
            new MovementData(0, 0),
            new MovementData(19.88f, 4.09f),
            new MovementData(39.44f, 8.37f),
            new MovementData(59.72f, 11.14f),
            new MovementData(80.96f, 16.4f),
            new MovementData(100, 20)
        };

        yield return movement.Running(datas);

        Assert.AreEqual(100, prevDistance, 1);
    }

    private void CheckDistanceChanged(object sender, MovementParametersArgs args)
    {
        Assert.IsTrue(args.Distance > prevDistance);
        prevDistance = args.Distance;
    }
}
