namespace Mindbox.Geometry.Core;

public class Circle : Figure
{
    public double Radius { get; }

    /// <param name="radius">A positive real number.</param>
    /// <exception cref="ArgumentException">Throws if the radius is less than 0.</exception>
    public Circle(double radius)
    {
        if (!radius.IsGreaterThanZero())
            throw new ArgumentException("Radius should be greater or equal than 0.");

        Radius = radius;
    }

    public override double GetArea() => Math.PI * Radius * Radius;

}
