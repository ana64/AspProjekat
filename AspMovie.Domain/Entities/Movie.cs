using System;
using System.Collections.Generic;


namespace AspMovie.Domain.Entities
{
    public class Movie : Entity
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Int64  RunTimeInMinutes { get; set; } //?  2h 22 min = 142 min
        public string Poster { get; set; }
        public virtual Certification Certification { get; set; } 
       

        public virtual ICollection<Genre>  Genres { get; set; } = new List<Genre>();
        public virtual ICollection<ActorMovie>  Actors { get; set; } = new List<ActorMovie>();
        public virtual ICollection<CrewMovie> CrewMovies { get; set; }

        
    }
}
