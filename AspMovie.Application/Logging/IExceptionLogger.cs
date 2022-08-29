using System;


namespace AspMovie.Application.Logging
{
    public interface IExceptionLogger
    {
        void Log(Exception exception);
    }
}
