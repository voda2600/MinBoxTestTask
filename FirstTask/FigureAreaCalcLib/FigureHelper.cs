using FigureAreaCalcLib.Figures;

namespace FigureAreaCalcLib;

public abstract class FigureHelper
{
    /// <summary>
    /// Вычисление площади фигуры по параметрам
    /// </summary>
    public static double CalculateArea(int accurate, params double[] sides)
    {
        var fig = FigureFactory.DefineFigureBySides(sides);

        return fig.CalculateArea(accurate);
    }
    
    /// <summary>
    /// Проверка треугольника на прямоугольность
    /// </summary>
    public static bool IsTriangleRectangular(double sideA, double sideB, double sideC)
    {
        var figure = FigureFactory.DefineFigureBySides(sideA, sideB, sideC);
        if (figure is Triangle triangle)
        {
            return triangle.IsRectangular();
        }

        return false;
    }
}