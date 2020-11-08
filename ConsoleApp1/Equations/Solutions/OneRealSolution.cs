namespace ConsoleApp1.Equations.Solutions
{
    public class OneRealSolution: IQuadraticEquationSolution
    {
        private readonly double _x0;

        public OneRealSolution(QuadraticEquation equation)
        {
            _x0 = -equation.B / (equation.A * 2);
        }

        public override string ToString()
        {
            return $"Równanie ma jedno rozwiązanie należące do zbioru liczb rzeczywistych: x0 = {_x0}";
        }
    }
}