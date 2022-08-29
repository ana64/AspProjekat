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
    public class EfAddCrewsCommand : EfUseCase, IAddCrewsCommand
    {
        public readonly CrewValidator validator;

        public EfAddCrewsCommand(ProjectDbContext context, CrewValidator validator) : base(context)
        {
            this.validator = validator;
        }

        public int Id => 10;

        public string Name => "Insert Crew for Movie";

        public string Description => "";

        ///*
        //      {
        //        "firstName":"",
        //        "lastName":"",
        //        "movieId":"",
        //        "jobId":""
        //      }
        //    */

        //// crew - first name,last name
        ////movie id
        ////job id
        public void Execute(CrewDto request)
        {
            validator.ValidateAndThrow(request);

            var crew = new Crew { FirstName = request.firstName, LastName = request.lastName };
            var movie = Context.Movies.FirstOrDefault(x => x.Id == request.movieId);
            var job = Context.Jobs.FirstOrDefault(x => x.Id == request.jobId);

            var crewMovies = new CrewMovie
            {
                Crew = crew,
                Movie = movie,
                Job = job
            };
           
            Context.CrewMovies.Add(crewMovies);
            Context.SaveChanges();
        }
    }
}
