

namespace AspMovie.Domain.Entities
{
    public class ActorMovie
    {
        public int ActorId { get; set; }
        public int MovieId { get; set; }
        public string Role { get; set; }


        public virtual Movie Movie { get; set; }
        public  virtual Actor Actor { get; set; }
    }
}
