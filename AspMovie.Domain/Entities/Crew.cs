using System.Collections.Generic;


namespace AspMovie.Domain.Entities
{
    public class Crew : People 
    {
        public virtual ICollection<CrewMovie> CrewMovies { get; set; }
    }

    public class CrewMovie
    {
        public int CrewId { get; set; }
        public int MovieId { get; set; }
        public int JobId { get; set; }

        public  virtual Crew Crew { get; set; }
        public virtual Movie Movie { get; set; }
        public  virtual Job Job { get; set; }
    }
}
