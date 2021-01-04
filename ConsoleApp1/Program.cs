using System;
using ConsoleApp1.Equations;
using ConsoleApp1.Io;

namespace ConsoleApp1
{
    static class Program
    {
        static void Main(string[] args)
        {
            var parameterProvider = new StandardIoParameterReader();
            var equationAssembler = new QuadraticEquation.QuadraticEquationAssembler(parameterProvider);
            var solutionPresenter = new StandardIoSolutionsWriter();
            for (;;)
            {
                try
                {
                    Console.WriteLine(
                        "Algorytm rozwiazuje równanie postaci a*x^2 + b*x + c = 0 dla zadanego a, b i c w zbiorze liczb rzeczywistych");
                    var equation = equationAssembler.Assemble();
                    Console.WriteLine($"Równanie po podaniu parametrów a, b i c ma postać {equation}");
                    Console.WriteLine(equation.Delta);
                    var solutions = equation.Solution;
                    solutionPresenter.ShowSolutions(solutions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}