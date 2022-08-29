
namespace AspMovie.Domain.Entities
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public int Star { get; set; }

        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
