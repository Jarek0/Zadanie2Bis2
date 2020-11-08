namespace ConsoleApp1.Equations
{
    public class NonZeroValidator: IParameterValidator
    {
        public bool IsValid(double parameter)
        {
            return !parameter.Equals(0.0);
        }
    }
}