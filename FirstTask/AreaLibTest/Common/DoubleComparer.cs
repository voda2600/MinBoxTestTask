using FigureAreaCalcLib.Interfaces;
using System.Collections.Generic;

namespace AreaLibTest.Common;

public class DoubleComparer : IEqualityComparer<double>
{
    public bool Equals(double x, double y)
    {
        return x - y < IHasAreaFigure.Accuracy;
    }

    public int GetHashCode(double obj)
    {
        return obj.GetHashCode();
    }
}