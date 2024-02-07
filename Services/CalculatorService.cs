using Calculator.Services.Interfaces;
using Calculator.Utils;

namespace Calculator.Services
{
    public class CalculatorService : ICalculatorService
    {
        public Task<double> DivisionAsync(params double[] numbers)
        {
            Task<double> divTask = new Task<double>(() => BasicMath.Division(numbers));
            divTask.Start();

            return divTask;
        }

        public Task<double> DifferenceAsync(params double[] numbers)
        {
            Task<double> diffTask = new Task<double>(() => BasicMath.Diff(numbers));
            diffTask.Start();

            return diffTask;
        }

        public Task<double> MultiplyAsync(params double[] numbers)
        {
            Task<double> multiplyTask = new Task<double>(() => BasicMath.Multiply(numbers));
            multiplyTask.Start();

            return multiplyTask;
        }

        public Task<double> SumAsync(params double[] numbers)
        {
            Task<double> sumTask = new Task<double>(() => BasicMath.Sum(numbers));
            sumTask.Start();

            return sumTask;
        }

        public Task<double> PowAsync(double foundation, double power)
        {
            Task<double> powTask = new Task<double>(() => BasicMath.Pow(foundation, power));
            powTask.Start();

            return powTask;
        }

        public Task<double> SqrtAsync(double value)
        {
            Task<double> sqrtTask = new Task<double>(() => BasicMath.Sqrt(value));
            sqrtTask.Start();

            return sqrtTask;
        }
    }
}