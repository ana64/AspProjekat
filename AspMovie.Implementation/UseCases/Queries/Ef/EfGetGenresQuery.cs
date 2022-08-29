using AspMovie.Application.UseCases.Dto;
using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.DataAccess;
using System.Collections.Generic;
using System.Linq;


namespace AspMovie.Implementation.UseCases.Queries.Ef
{
    public class EfGetGenresQuery : EfUseCase, IGetGenresQuery
    {

        public int Id => 1;

        public string Name => "Search Genres";

        public string Description => "Search Genres using Entity Framework.";

        public EfGetGenresQuery(ProjectDbContext context) : base(context)   {   }

        public PagedResponse<GenreDto> Execute(BasePagedSearch search)
        {
            var query = Context.Genres.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                query = query.Where(x => x.GenreName.Contains(search.Keyword));
            }

            if (search.PerPage == null || search.PerPage < 1)
            {
                search.PerPage = 20;
            }

            if (search.Page == null || search.Page < 1)
            {
                search.PerPage = 1;
            }

            var toSkip = (search.Page.Value - 1) * search.PerPage.Value;

            var response = new PagedResponse<GenreDto>();
            response.TotalCount = query.Count();

            response.Data = query.Skip(toSkip).Take(search.PerPage.Value).Select(x => new GenreDto
            {
                Genre = x.GenreName,
                Id = x.Id
            })
            .ToList();

            response.CurrentPage = search.Page.Value;
            response.ItemsPerPage = search.PerPage.Value;
            

            return response;
   
        }


    }
}
