using System;
using ConsoleApp1.Equations.Solutions;

namespace ConsoleApp1.Equations
{
    public class QuadraticEquation
    {

        private double _a;
        public double A
        {
            get { return _a; }
            private set
            {
                IParameterValidator aParameterValidator = new NonZeroValidator();
                if (!aParameterValidator.IsValid(value))
                {
                    throw new ArgumentException("Współczynnik a nie może być równy 0. Podaj go ponownie.");
                }
                _a = value;
        } }
        public double B { get; private set; }
        public double C { get; private set; }
        public Delta Delta => new Delta(this);

        public IQuadraticEquationSolution Solution => QuadraticEquationSolver.Solve(this, this.Delta);

        private QuadraticEquation(double a, double b, double c)
        {
            A = a;
            B = b;
            C = c;
        }
        
        private QuadraticEquation()
        {
            _a = 0;
            B = 0;
            C = 0;
        }
        
        public override string ToString()
        {
            return $"({A}*x^2) + ({B}*x) + ({C}) = 0";
        }
        public class QuadraticEquationAssembler
        {

            private readonly IEquationParameterProvider _parameterProvider;
            private const string ParametrizedConstructor = "a";
            private const string NotParametrizedConstructor = "b";

            public QuadraticEquationAssembler(IEquationParameterProvider parameterProvider)
            {
                this._parameterProvider = parameterProvider;
            }

            public QuadraticEquation Assemble()
            {
                var wayOfCreation = WayOfCreationQuadraticEquation();
                if (wayOfCreation != null && wayOfCreation.Equals(ParametrizedConstructor))
                {
                    return AssembleUsingParamConstructor();
                }
                if (wayOfCreation != null && wayOfCreation.Equals(NotParametrizedConstructor))
                {
                    return AssembleUsingNotParamConstructor();
                }
                throw new Exception("Nieprawidłowy wartość określająca sposób tworzenia równania kwadratowego");
            }

            private static string WayOfCreationQuadraticEquation()
            {
                for (;;)
                {
                    try
                    {
                        Console.WriteLine("Wpisz a żeby stworzyć równanie poprzez konstruktor z parametrami");
                        Console.WriteLine("Wpisz b żeby stworzyć równanie poprzez konstruktor z parametrami");
                        string userInput = Console.ReadLine();
                        if (userInput.Equals(ParametrizedConstructor) || userInput.Equals(NotParametrizedConstructor))
                        {
                            return userInput;
                        }
                        throw new Exception("Nieprawidłowy wartość określająca sposób tworzenia równania kwadratowego");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Podałeś nieprawidłowy sposób tworzenia równania kwadratowego! Spróbuj jeszcze raz!");
                    }
                }
            }
            
            private QuadraticEquation AssembleUsingParamConstructor()
            {
                var a = _parameterProvider.Provide("a");
                var b = _parameterProvider.Provide("b");
                var c = _parameterProvider.Provide("c");
                return new QuadraticEquation(a, b, c);
            }
            
            private QuadraticEquation AssembleUsingNotParamConstructor()
            {
                var equation = new QuadraticEquation
                {
                    A = _parameterProvider.Provide("a"), B = _parameterProvider.Provide("b"), C = _parameterProvider.Provide("c")
                };
                return equation;
            }
        }
    }
}