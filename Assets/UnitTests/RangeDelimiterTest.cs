using NUnit.Framework;
using System.Linq;

public class RangeDelimiterTest
{
    [Theory]
    [TestCase(100f, 5, 5)]
    [TestCase(100f, 5, 4)]
    public void RangeDelimiter_Get(float value, float difference, int count)
    {
        float[] lines = RangeDelimiter.Get(value, difference, count);
        float sum = 0;
        for (int i = 0; i < lines.Count() - 1; i++)
        {
            sum += lines[i + 1] - lines[i];
        }
        Assert.AreEqual(value, sum, 0.001);
    }
}
