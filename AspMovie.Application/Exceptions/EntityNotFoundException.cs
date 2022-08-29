using System;


namespace AspMovie.Application.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string entityType, int id)
           : base($"Entity of type {entityType} with an id of {id} was not found.")
        {
        }
    }
}
