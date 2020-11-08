using System;
using ConsoleApp1.Equations;
using ConsoleApp1.Equations.Solutions;

namespace ConsoleApp1.Io
{
    public class StandardIoSolutionsWriter
    {
        public void ShowSolutions(IQuadraticEquationSolution solution)
        {
            Console.WriteLine(solution);
        }
        
    }
}