using AspMovie.Application.Logging;
using System;


namespace Implementation.Logging
{
    public class ConsoleExceptionLogger : IExceptionLogger
    {
        public void Log(Exception exception)
        {
            Console.WriteLine("Occured at: " + DateTime.UtcNow);
            Console.WriteLine(exception.Message);
        }
    }
}
