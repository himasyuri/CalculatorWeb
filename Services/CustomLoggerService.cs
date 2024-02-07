using Calculator.Services.Interfaces;

namespace Calculator.Services
{
    public class CustomLoggerService : ICustomLoggerService
    {
        private string logsPath;

        public CustomLoggerService()
        {
            logsPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
        }

        public CustomLoggerService(string logsPath)
        {
            if (logsPath == null || logsPath == string.Empty)
            {
                logsPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            }
            if (Directory.Exists(logsPath))
            {
                this.logsPath = logsPath;
            }
            else
            {
                Console.WriteLine($"Directory {logsPath} was created");
                
                Directory.CreateDirectory(logsPath);

                using (var sw = new StreamWriter(Path.Combine(logsPath, "logs.text"), true))
                {
                    sw.WriteLine("Logs started");
                    sw.WriteLine($"Directory {logsPath} was created");
                }

                this.logsPath = logsPath;
            }
        }

        public void ErrorLog(Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine("ERROR:", exception.Message);

            using (var sw = new StreamWriter(Path.Combine(logsPath, "logs.txt"), true))
            {
                sw.WriteLine("=======================================================");
                sw.WriteLine("=======================================================");
                sw.WriteLine($"Time: {DateTime.UtcNow} Exception message: {exception.Message}");
                sw.WriteLine($"ERROR:{exception}");
                sw.WriteLine();
            }
        }

        public void Log(Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine(exception.Message);

            using (var sw = new StreamWriter(Path.Combine(logsPath, "logs.txt"), true))
            {
                sw.WriteLine("=======================================================");
                sw.WriteLine("=======================================================");
                sw.WriteLine($"Time: {DateTime.UtcNow} Exception message: {exception.Message}");
                sw.WriteLine(exception.ToString());
                sw.WriteLine();
            }
        }

        public void WarnLog(Exception exception)
        {
            Console.WriteLine(exception);
            Console.WriteLine($"WARN:{exception.Message}");

            using (var sw = new StreamWriter(Path.Combine(logsPath, "logs.txt"), true))
            {
                sw.WriteLine("=======================================================");
                sw.WriteLine("=======================================================");
                sw.WriteLine($"WARN Time: {DateTime.UtcNow} Exception message: {exception.Message}");
                sw.WriteLine();
            }
        }
    }
}