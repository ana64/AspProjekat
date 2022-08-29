using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.Application.UseCases.Dto
{
    public class RateDto
    {
        public int  movieId { get; set; } //fk
        public int  userId { get; set; } //fk
        public int  star { get; set; } //  1-10 
    }
}
