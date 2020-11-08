using System;
using ConsoleApp1.Equations.Solutions;

namespace ConsoleApp1.Equations
{
    public class QuadraticEquation
    {

        private readonly double _a;
        private readonly double _b;
        private readonly double _c;

        private QuadraticEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        
        public IQuadraticEquationSolution FindSolutionsInRealNumbers(Delta delta)
        {
            return QuadraticEquationSolver.Solve(this, delta);
        }
        
        public override string ToString()
        {
            return $"({_a}*x^2) + ({_b}*x) + ({_c}) = 0";
        }

        public double A => _a;

        public double B => _b;
        
        public double C => _c;
        
        public class QuadraticEquationAssembler
        {

            private readonly IEquationParameterProvider _parameterProvider;
            private readonly IParameterValidator _aParameterValidator = new NonZeroValidator();

            public QuadraticEquationAssembler(IEquationParameterProvider parameterProvider)
            {
                this._parameterProvider = parameterProvider;
            }
            
            public QuadraticEquation Assemble()
            {
                var a = _parameterProvider.Provide("a");
                if (!_aParameterValidator.IsValid(a))
                {
                    throw new ArgumentException("Współczynnik a nie może być równy 0. Podaj go ponownie.");
                }
                var b = _parameterProvider.Provide("b");
                var c = _parameterProvider.Provide("c");
                return new QuadraticEquation(a, b, c);
            }
        }
    }
}