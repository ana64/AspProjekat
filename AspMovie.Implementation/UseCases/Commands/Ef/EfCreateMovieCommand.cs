using AspMovie.Application.UseCases.Commands;
using AspMovie.Application.UseCases.Dto;
using AspMovie.DataAccess;
using AspMovie.Domain.Entities;
using AspMovie.Implementation.Validators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspMovie.Implementation.UseCases.Commands.Ef
{
    public class EfCreateMovieCommand : EfUseCase, ICreateMovieCommand
    {
        public MovieValidator validator;

        public EfCreateMovieCommand(ProjectDbContext context, MovieValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 9;

        public string Name => "Create Movie";

        public string Description => "";

        public void Execute(CreateMovieDto request)
        {
            validator.ValidateAndThrow(request);

            var certificate = Context.Certifications
                                     .FirstOrDefault(c => c.CertificationId == request.CertificateId);

            var movie = new Movie
            {
                Title = request.Title,
                ReleaseDate = request.ReleaseDate,
                RunTimeInMinutes = request.Runtime,  
                Certification =certificate,
                Poster = request.PosterFileName
            };
           

            Context.Movies.Add(movie);
            Context.SaveChanges();
        }
    }
}
