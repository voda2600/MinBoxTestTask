using FigureAreaCalcLib.Figures;
using FigureAreaCalcLib.Interfaces;

namespace FigureAreaCalcLib;

internal abstract class FigureFactory
{
    private static readonly Dictionary<int, Func<double[], IHasAreaFigure>> FigureDictionary = new()
    {
        { 1, sides => new Circle(sides[0]) },
        { 3, sides => new Triangle(sides[0], sides[1], sides[2]) },
    };

    public static IHasAreaFigure DefineFigureBySides(params double[] sides)
    {
        if (FigureDictionary.TryGetValue(sides.Length, out var factory))
        {
            return factory(sides);
        }

        throw new ArgumentException();
    }
}