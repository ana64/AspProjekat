using AspMovie.Application.UseCases.Dto;
using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.DataAccess;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace AspMovie.Implementation.UseCases.Queries.Ef
{
    public class EfGetMoviesQuery : EfUseCase, IGetMoviesQuery
    {
        public EfGetMoviesQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "List of Movies";

        public string Description => "";

        public IEnumerable<MovieDto> Execute(BasePagedSearch request)
        {
            var query = Context.Movies.AsQueryable();

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword));
            }

            return query.Select(x => new MovieDto
            {
                Title = x.Title,
                ReleaseDate = x.ReleaseDate,
                Runtime = (int)x.RunTimeInMinutes,
                Stars = Context.Ratings.Where(r => r.MovieId == x.Id).Average(x => x.Star),
                Director = JsonConvert.SerializeObject
                (
                    x.CrewMovies
                         .Where(x => x.Job.Name == "director")
                         .Select(x => x.Crew.FirstName + " " + x.Crew.LastName)
                )                   
            }) .ToList();
        }

      
    }
}
