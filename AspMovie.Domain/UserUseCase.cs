namespace AspMovie.Domain
{
    public class UserUseCase 
    {
        public int UserId { get; set; }
        public int UseCaseId { get; set; }

        public virtual User User { get; set; }
    }
}