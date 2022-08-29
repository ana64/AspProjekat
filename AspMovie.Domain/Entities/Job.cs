using System.Collections.Generic;

namespace AspMovie.Domain.Entities
{
    public class Job : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<CrewMovie> CrewMovies { get; set; }   
    }
}
