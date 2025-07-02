using NUnit.Framework;
using System.Linq;

public class MovementCreatorTest
{ 
    [Test]
    public void MovementCreator_Create()
    {
        var result = MovementCreator.Create(distance: 100, differenceDistance: 5, time: 20, differenceTime: 1, pointCount: 5);

        Assert.AreEqual(100, result.Skip(1).Select((v, i) => v.Distance - result[i].Distance).Sum());
        Assert.AreEqual(20, result.Skip(1).Select((v, i) => v.Time - result[i].Time).Sum());
    }
}
