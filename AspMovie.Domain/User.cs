using System.Collections.Generic;


namespace AspMovie.Domain
{
    public class User : People
    {      
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual ICollection<UserUseCase> UseCases { get; set; }
    }
}
