namespace ConsoleApp1.Equations.Solutions
{
    public class QuadraticEquationSolver
    {
        public static IQuadraticEquationSolution Solve(QuadraticEquation equation, Delta delta)
        {
            if (delta > 0) return new TwoRealSolutions(equation, delta);
            if (delta < 0) return new ZeroRealSolutions();
            return new OneRealSolution(equation);
        }
    }
}