using System;
using ConsoleApp1.Equations.Solutions;

namespace ConsoleApp1.Equations
{
    public class QuadraticEquation
    {

        private double _a;
        private double _b;
        private double _c;
        
        private QuadraticEquation(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }
        
        private QuadraticEquation()
        {
            _a = 0;
            _b = 0;
            _c = 0;
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
            private const string ParametrizedConstructor = "a";
            private const string NotParametrizedConstructor = "b";

            public QuadraticEquationAssembler(IEquationParameterProvider parameterProvider)
            {
                this._parameterProvider = parameterProvider;
            }

            public QuadraticEquation Assemble()
            {
                for (;;)
                {
                    try
                    {
                        Console.WriteLine("Wpisz a żeby stworzyć równanie poprzez konstruktor z parametrami");
                        Console.WriteLine("Wpisz b żeby stworzyć równanie poprzez konstruktor z parametrami");
                        string userInput = Console.ReadLine();
                        if (userInput != null && userInput.Equals(ParametrizedConstructor))
                        {
                            return AssembleUsingParamConstructor();
                        }
                        if (userInput != null && userInput.Equals(NotParametrizedConstructor))
                        {
                            return AssembleUsingNotParamConstructor();
                        }
                        throw new Exception("Nieprawidłowy wartość określająca sposób tworzenia równania kwadratowego");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Podałeś nieprawidłowy sposób tworzenia równania kwadratowego! Spróbuj jeszcze raz!");
                    }
                }
            }
            
            public QuadraticEquation AssembleUsingParamConstructor()
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
            
            public QuadraticEquation AssembleUsingNotParamConstructor()
            {
                var a = _parameterProvider.Provide("a");
                if (!_aParameterValidator.IsValid(a))
                {
                    throw new ArgumentException("Współczynnik a nie może być równy 0. Podaj go ponownie.");
                }
                var equation = new QuadraticEquation
                {
                    _a = a, _b = _parameterProvider.Provide("b"), _c = _parameterProvider.Provide("c")
                };
                return equation;
            }
        }
    }
}