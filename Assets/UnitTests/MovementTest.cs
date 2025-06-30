using NUnit.Framework;
using System.Collections;
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
    }

    [TearDown]
    public void TearDown()
    {
        movement.DistanceChanged -= CheckDistanceChanged;
    }

    [UnityTest]
    public IEnumerator GameManager_Running_OneSubPath()
    {
        var subDistances = new float[] { 0, 15 };
        var subTimes = new float[] { 0, 5 };

        yield return movement.Running(subDistances, subTimes);

        Assert.AreEqual(15, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator GameManager_Running_TwoSubPath()
    {
        var subDistances = new float[] { 0, 15, 25 };
        var subTimes = new float[] { 0, 5, 9 };

        yield return movement.Running(subDistances, subTimes);

        Assert.AreEqual(25, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator GameManager_Running_ThreeSubPath()
    {
        var subDistances = new float[] { 0, 15, 25, 30 };
        var subTimes = new float[] { 0, 5, 9, 10 };

        yield return movement.Running(subDistances, subTimes);

        Assert.AreEqual(30, prevDistance, 1);
    }

    [UnityTest]
    public IEnumerator GameManager_Running_FiveSubPath()
    {
        var subDistances = new float[] { 0, 19.88f, 39.44f, 59.72f, 80.96f, 100 };
        var subTimes = new float[] { 0, 4.09f, 8.37f, 11.14f, 16.4f, 20 };

        yield return movement.Running(subDistances, subTimes);

        Assert.AreEqual(30, prevDistance, 1);
    }

    private void CheckDistanceChanged(object sender, MovementParametersArgs args)
    {
        Assert.IsTrue(args.Distance > prevDistance);
        prevDistance = args.Distance;
    }
}
