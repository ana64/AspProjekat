using System;


namespace AspMovie.Application.Exceptions
{
    public class UseCaseConflictException :Exception
    {
        public UseCaseConflictException(string message) : base(message)   {  }
    }
}
