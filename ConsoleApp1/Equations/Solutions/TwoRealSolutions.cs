using System;

namespace ConsoleApp1.Equations.Solutions
{
    public class TwoRealSolutions: IQuadraticEquationSolution
    {
        private readonly double _x1;
        private readonly double _x2;

        public TwoRealSolutions(QuadraticEquation equation, Delta delta)
        {
            var sqrtDelta = Math.Sqrt(delta.Value);
            _x1 = (-equation.B + sqrtDelta) / (equation.A * 2);
            _x2 = (-equation.B - sqrtDelta) / (equation.A * 2);
        }

        public override string ToString()
        {
            return $"Równanie ma dwa rozwiązanie należące do zbioru liczb rzeczywistych: x1 = {_x1}; x2 = {_x2}";
        }
    }
}