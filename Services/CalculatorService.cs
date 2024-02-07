using Calculator.Services.Interfaces;
using Calculator.Utils;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public async Task<double> DivisionAsync(params double[] numbers)
        {
            return await Task.Run(() => BasicMath.Division(numbers));
        }

        public async Task<double> DifferenceAsync(params double[] numbers)
        {
            return await Task.Run(() => BasicMath.Diff(numbers));
        }

        public async Task<double> MultiplyAsync(params double[] numbers)
        {
            return await Task.Run(() => BasicMath.Multiply(numbers));
        }

        public async Task<double> SumAsync(params double[] numbers)
        {
            return await Task.Run(() => BasicMath.Sum(numbers));
        }

        public async Task<double> PowAsync(double foundation, double power)
        {
            return await Task.Run(() => BasicMath.Pow(foundation, power));
        }

        public async Task<double> SqrtAsync(double value)
        {
            return await Task.Run(() => BasicMath.Sqrt(value));
        }
    }
}