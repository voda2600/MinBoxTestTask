using FigureAreaCalcLib.Figures;

namespace FigureAreaCalcLib;

public abstract class FigureHelper
{
    /// <summary>
    /// Вычисление площади фигуры с автоматическим определением типа фигуры
    /// </summary>
    public static double CalculateArea(int accurate, params double[] sides)
    {
        var figure = FigureFactory.DefineFigureBySides(sides);

        return figure.CalculateArea(accurate);
    }
    
    /// <summary>
    /// Проверка треугольника на прямоугольность
    /// </summary>
    public static bool IsTriangleRectangular(double sideA, double sideB, double sideC)
    {
        var triangle = new Triangle(sideA, sideB, sideC);
        return triangle.IsRectangular();
    }
}