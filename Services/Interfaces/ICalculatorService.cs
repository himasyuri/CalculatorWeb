namespace Calculator.Services.Interfaces
{
    public interface ICalculatorService
    {
        Task<double> SumAsync(params double[] numbers);

        Task<double> DivisionAsync(params double[] numbers);

        Task<double> DifferenceAsync(params double[] numbers);

        Task<double> MultiplyAsync(params double[] numbers);

        Task<double> PowAsync(double foundation, double power);

        Task<double> SqrtAsync(double value);
    }
}