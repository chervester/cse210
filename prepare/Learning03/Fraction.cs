namespace Learning03
{
    public class Fraction
    {
        // Private attributes for the numerator and denominator
        private int _numerator;
        private int _denominator;

        // Default constructor that initializes the fraction to 1/1
        public Fraction()
        {
            _numerator = 1;
            _denominator = 1;
        }

        // Constructor that takes one parameter for the numerator and initializes denominator to 1
        public Fraction(int numerator)
        {
            _numerator = numerator;
            _denominator = 1;
        }

        // Constructor that takes two parameters (numerator and denominator)
        public Fraction(int numerator, int denominator)
        {
            _numerator = numerator;
            _denominator = denominator;
        }

        // Getter for Numerator
        public int GetNumerator()
        {
            return _numerator;
        }

        // Setter for Numerator
        public void SetNumerator(int numerator)
        {
            _numerator = numerator;
        }

        // Getter for Denominator
        public int GetDenominator()
        {
            return _denominator;
        }

        // Setter for Denominator
        public void SetDenominator(int denominator)
        {
            _denominator = denominator;
        }

        // Method to return fraction as a string "numerator/denominator"
        public string GetFractionString()
        {
            return $"{_numerator}/{_denominator}";
        }

        // Method to return the decimal value of the fraction
        public double GetDecimalValue()
        {
            return (double)_numerator / _denominator;
        }
    }
}
