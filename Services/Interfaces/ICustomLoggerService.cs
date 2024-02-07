namespace Calculator.Services.Interfaces
{
    public interface ICustomLoggerService
    {
        void Log(Exception exception);

        void WarnLog(Exception exception);

        void ErrorLog(Exception exception);
    }
}