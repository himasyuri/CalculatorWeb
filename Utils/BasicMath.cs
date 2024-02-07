namespace Calculator.Utils
{
    public class BasicMath
    {
        public static double Sum(params double[] numbers)
        {
            double result = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }

            return result;
        }

        public static double Diff(params double[] numbers)
        {
            double result = numbers[0];

            for (int i = 1; i < numbers.Length; i++)
            {
                result -= numbers[i];
            }

            return result;
        }

        public static double Multiply(params double[] numbers)
        {
            double result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result *= numbers[i];
            }

            return result;
        }

        public static double Division(params double[] numbers)
        {
            double result = numbers[0]; // numerator
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    throw new ArgumentException("Can't divide by zero");
                }
                if (numbers[0] == 0 && numbers[i] == 0)
                {
                    throw new ArgumentException("Can't divide zero by zero");
                }

                result /= numbers[i];
            }

            return result;
        }

        public static double Pow(double foundation, double power)
        {
            if (foundation == 0 && power == 0)
            {
                throw new ArgumentException("0 in power 0 is uncertainty");
            }
            return Math.Pow(foundation, power);
        }

        public static double Sqrt(double value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Radical expression can't be negative");
            }
            return Math.Sqrt(value);
        }
    }
}