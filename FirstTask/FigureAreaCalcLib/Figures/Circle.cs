using FigureAreaCalcLib.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace FigureAreaCalcLib.Figures;

/// <inheritdoc />
public class Circle : IHasAreaFigure
{
    private readonly double _r;

    public Circle(double r)
    {
        Validate(r);
        _r = r;
    }

    public double CalculateArea()
    {
        return Math.PI * (_r * _r);


    }
    public double GetRadius()
    {
        return _r;
    }

    private static void Validate(double r)
    {
        if (r <= 0)
        {
            throw new ArgumentException("The radius of the circle is negative or zero");
        }
    }
}