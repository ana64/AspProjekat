using System;

namespace AspMovie.Domain
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
    }

    public abstract class People : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
