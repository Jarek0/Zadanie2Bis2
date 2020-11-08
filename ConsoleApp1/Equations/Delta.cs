namespace ConsoleApp1.Equations
{
    public class Delta
    {
        private bool Equals(Delta other)
        {
            return _value.Equals(other._value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Delta) obj);
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        private readonly double _value;

        public double Value => _value;

        public Delta(QuadraticEquation equation)
        {
            _value = equation.B*equation.B - 4*equation.A*equation.C;
        }
        
        public static bool operator <(Delta delta, double value) {
            return delta._value < value;
        }
        
        public static bool operator >(Delta delta, double value) {
            return delta._value > value;
        }
        
        public static bool operator ==(Delta delta, double value) {
            return delta != null && delta._value.Equals(value);
        }
        
        public static bool operator !=(Delta delta, double value) {
            return delta != null && !delta._value.Equals(value);
        }
        
        public override string ToString()
        {
            return $"delta = {_value}";
        }
    }
}