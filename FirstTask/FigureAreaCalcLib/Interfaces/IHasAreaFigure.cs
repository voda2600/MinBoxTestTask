﻿namespace FigureAreaCalcLib.Interfaces;

/// <summary>
/// Интерфейс фигуры с площадью
/// </summary>
public interface IHasAreaFigure
{
    /// <summary>
    /// Вычисление площади
    /// </summary>
    public double CalculateArea();

    public const double Accuracy = 0.001;
}