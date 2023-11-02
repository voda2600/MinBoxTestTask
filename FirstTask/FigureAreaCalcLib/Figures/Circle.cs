using FigureAreaCalcLib.Dto;
using FigureAreaCalcLib.Interfaces;

namespace FigureAreaCalcLib.Figures;

/// <inheritdoc />
public class Circle : IHasAreaFigure
{
    private readonly double _r;

    public Circle(CircleData circleData)
    {
        Validate(circleData);
        _r = circleData.R;
    }

    public double CalculateArea()
    {
        return Math.PI * (_r * _r);
    }

    private static void Validate(CircleData circleData)
    {
        if (circleData is null)
        {
            throw new ArgumentException();
        }

        if (circleData.R < 0)
        {
            throw new ArgumentException("The radius of the circle is negative");
        }
    }
}