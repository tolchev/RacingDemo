using NUnit.Framework;

public class MovementCreatorTest
{ 
    [Test]
    public void MovementCreator_Create()
    {
        MovementCreator creator = new MovementCreator();

        var tuple = creator.Create(distance: 100, differenceDistance: 5, time: 20, differenceTime: 1, pointCount: 5);
    }
}
