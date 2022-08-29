using System.Collections.Generic;

namespace AspMovie.Domain.Entities
{
    public class Genre : Entity
    {
        public string GenreName { get; set; }
        public virtual  ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}
