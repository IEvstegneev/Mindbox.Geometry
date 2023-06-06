using Mindbox.Geometry.Core;

namespace Mindbox.Geometry.UnitTests;

public class CircleTests
{

    [Theory]
    [InlineData(-1.0, typeof(ArgumentException))]
    [InlineData(double.NaN, typeof(ArgumentException))]
    [InlineData(double.NegativeInfinity, typeof(ArgumentException))]
    public void Circle_CreateCircle_ShouldFailed(double radius, Type exceptionType)
    {
        var act = () =>
        {
            var circle = new Circle(radius);
        };

        Assert.Throws(exceptionType, act);
    }

    [Theory]
    [InlineData(0.0, 0.0)]
    [InlineData(1.0, Math.PI)]
    [InlineData(200.1, 40040.01 * Math.PI)]
    [InlineData(200.1, 200.1 * 200.1 * Math.PI)]
    [InlineData(double.MaxValue, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity)]
    public void Circle_GetArea_ShouldSuccessed(double radius, double expectedArea)
    {
        var circle = new Circle(radius);

        var area = circle.GetArea();

        Assert.Equal(expectedArea, area, 0.0000001);
    }

    [Theory]
    [InlineData(double.MaxValue, typeof(OverflowException))]
    [InlineData(double.PositiveInfinity, typeof(OverflowException))]
    public void Circle_GetAreaOrFail_ShouldFailed(double radius, Type exceptionType)
    {
        var circle = new Circle(radius);

        var act = () =>
        {
            var area = circle.GetAreaOrFail();
        };

        Assert.Throws(exceptionType, act);
    }
}