using FigureAreaCalcLib.Interfaces;

namespace FigureAreaCalcLib.Figures;

/// <inheritdoc />
internal class Triangle : IHasAreaFigure
{
    private readonly (double A, double B, double C) _triangleData;

    public Triangle(double a, double b, double c)
    {
        var triangleData = (a, b, c);
        Validate(triangleData);
        _triangleData = triangleData;
    }

    public double CalculateArea(int accurate)
    {
        var halfPerimeter = (_triangleData.A + _triangleData.B + _triangleData.C) / 2;
        
        return Math.Round(Math.Sqrt(halfPerimeter * (halfPerimeter - _triangleData.A) * (halfPerimeter - _triangleData.B) *
                         (halfPerimeter - _triangleData.C)), accurate);
    }

    public bool IsRectangular()
    {
        return _triangleData.A * _triangleData.A + _triangleData.B * _triangleData.B -
               _triangleData.C * _triangleData.C < double.Epsilon
               || _triangleData.A * _triangleData.A + _triangleData.C * _triangleData.C -
               _triangleData.B * _triangleData.B < double.Epsilon
               || _triangleData.C * _triangleData.C + _triangleData.B * _triangleData.B -
               _triangleData.A * _triangleData.A < double.Epsilon;
    }

    private static void Validate((double A, double B, double C) triangleData)
    {
        var triangleIsValid = triangleData is { A: > 0, B: > 0, C: > 0 }
                              && triangleData.A + triangleData.B > triangleData.C
                              && triangleData.A + triangleData.C > triangleData.B
                              && triangleData.B + triangleData.C > triangleData.A;
        if (!triangleIsValid)
        {
            throw new ArgumentException("A triangle with such sides does not exist");
        }
    }
}