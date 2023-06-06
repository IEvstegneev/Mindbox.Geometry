namespace Mindbox.Geometry.Core;

public class Triangle : Figure
{
    public TriangleParams Params { get; }
    public double Perimeter => Params.A + Params.B + Params.C;
    public double HalfPerimeter => Perimeter / 2;

    public Triangle(TriangleParams triangleParams)
    {
        Params = triangleParams;
    }

    public override double GetArea()
    {
        return Math.Sqrt(HalfPerimeter * Params.Aggregate(1.0, (seed, p) => seed *= HalfPerimeter - p));
    }

    public bool IsRight()
    {
        var hypotenuse = Params.Max();

        var catheters = Params.Where(x => x != hypotenuse).ToList();

        if (catheters.Count != 2)
            return false;

        var areaByCatheters = catheters[0] * catheters[1] / 2;

        return Math.Round(areaByCatheters, 7) == Math.Round(GetArea(), 7);
    }
}
