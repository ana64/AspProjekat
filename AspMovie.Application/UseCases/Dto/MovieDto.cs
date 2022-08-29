using AspMovie.Domain.Entities;
using System;
using System.Collections.Generic;

namespace AspMovie.Application.UseCases.Dto
{
    public class MovieDto : BaseDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public double Stars { get; set; }

    }

    public class CreateMovieDto
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Runtime { get; set; }
        public int CertificateId { get; set; }
        public string PosterFileName { get; set; }


    }
}
