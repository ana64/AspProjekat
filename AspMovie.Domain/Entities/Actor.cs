using System;
using System.Collections.Generic;


namespace AspMovie.Domain.Entities
{
    public class Actor : People
    {
        public DateTime? Born { get; set; }
        public string Biography { get; set; }


        public  virtual ICollection<ActorMovie> ActorMovies { get; set; } = new List<ActorMovie>();

    }
}
