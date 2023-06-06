namespace Mindbox.Geometry.Core;

public abstract class Figure
{
    // Какая нужна точность для хранения значения радиуса?
    // Возьмём double
    public abstract double GetArea();

    /// <exception cref="OverflowException">Throws if could not calculate the area.</exception>
    public virtual double GetAreaOrFail()
    {
        // При вычислении возможно переполнение типа с возратом бесконечности.
        // Ожидает ли клиент такой результат?
        var area = GetArea();

        if (double.IsInfinity(area) || double.IsNaN(area))
            throw new OverflowException("Cann't calculate the area. The figure is too large.");

        if (double.IsNaN(area))
            throw new InvalidOperationException("Cann't calculate the area.");

        return area;
    }
}
