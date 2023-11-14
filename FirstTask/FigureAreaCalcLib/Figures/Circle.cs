using FigureAreaCalcLib.Interfaces;

namespace FigureAreaCalcLib.Figures;

/// <inheritdoc />
internal class Circle : IHasAreaFigure
{
    private readonly double _r;

    public Circle(double r)
    {
        Validate(r);
        _r = r;
    }

    public double CalculateArea(int accurate)
    {
        return Math.Round(Math.Round(Math.PI,2) * (_r * _r), accurate);
    }

    private static void Validate(double r)
    {
        if (r < 0)
        {
            throw new ArgumentException("The radius of the circle is negative");
        }
    }
}