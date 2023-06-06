using System.Collections;

namespace Mindbox.Geometry.Core;

public readonly struct TriangleParams : IEnumerable<double>
{
    public double A { get; }
    public double B { get; }
    public double C { get; }

    public TriangleParams(double a, double b, double c)
    {
        if (!(a >= .0 && b >= .0 && c >= .0))
            throw new ArgumentException("Parameters should be greater or equal than 0.");

        A = a;
        B = b;
        C = c;
    }

    public IEnumerator<double> GetEnumerator()
    {
        yield return A;
        yield return B;
        yield return C;
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}