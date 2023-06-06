using Mindbox.Geometry.Core;

namespace Mindbox.Geometry.UnitTests;

public class TriangleTests
{
    [Theory]
    [InlineData(-1.0, typeof(ArgumentException))]
    [InlineData(double.NaN, typeof(ArgumentException))]
    [InlineData(double.NegativeInfinity, typeof(ArgumentException))]
    public void Triangle_CreateTriangle_ShouldFailed(double value, Type exceptionType)
    {

        var act = () =>
        {
            var args = new TriangleParams(value, value, value);
            var triangle = new Triangle(args);
        };

        Assert.Throws(exceptionType, act);
    }

    [Theory]
    [InlineData(0.0, 0.0, 0.0, 0.0)]
    [InlineData(1.0, 1.0, 1.0, 0.433012702)]
    [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, double.PositiveInfinity)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, double.NaN)]
    public void Triangle_GetArea_ShouldSuccessed(double a, double b, double c, double expectedArea)
    {
        var args = new TriangleParams(a, b, c);

        var triangle = new Triangle(args);

        var area = triangle.GetArea();

        Assert.Equal(expectedArea, area, 0.0000001);
    }

    [Theory]
    [InlineData(double.MaxValue, typeof(OverflowException))]
    [InlineData(double.PositiveInfinity, typeof(OverflowException))]
    public void Triangle_GetAreaOrFail_ShouldFailed(double value, Type exceptionType)
    {
        var act = () =>
        {
            var args = new TriangleParams(value, value, value);
            var triangle = new Triangle(args);
            var area = triangle.GetAreaOrFail();
        };

        Assert.Throws(exceptionType, act);
    }

    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(0.20, 0.99, 1.01, true)]
    [InlineData(1, 1, 1.41421356, true)]
    [InlineData(3, 4, 6, false)]
    [InlineData(0.20, 0.99, 1.00, false)]
    [InlineData(0.0, 0.0, 0.0, false)]
    [InlineData(double.MaxValue, double.MaxValue, double.MaxValue, false)]
    [InlineData(double.PositiveInfinity, double.PositiveInfinity, double.PositiveInfinity, false)]
    public void Triangle_IsRigth_ShouldSuccessed(double a, double b, double c, bool expected)
    {
        var args = new TriangleParams(a, b, c);

        var triangle = new Triangle(args);

        var isRigth = triangle.IsRight();

        Assert.Equal(expected, isRigth);
    }
}