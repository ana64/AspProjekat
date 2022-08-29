using AspMovie.Application.UseCases.Dto.Searches;
using AspMovie.Application.UseCases.Queries;
using AspMovie.Application.UseCases.Queries.Dto;
using AspMovie.DataAccess;
using System.Linq;


namespace AspMovie.Implementation.UseCases.Queries.Ef
{
    public class EfGetActorsQuery : EfUseCase,IGetActorsQuery
    {
        public EfGetActorsQuery(ProjectDbContext context) : base(context)
        {
        }

        public int Id => 3;

        public string Name => "List of Actors";

        public string Description => "Information about Actors";

        public PagedResponse<ActorDto> Execute(BasePagedSearch search)
        {
            var actors = Context.Actors.AsQueryable();

            if (!string.IsNullOrEmpty(search.Keyword))
            {
                actors = actors.Where(x => x.FirstName.Contains(search.Keyword) || 
                                      x.LastName.Contains(search.Keyword));
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

            var response = new PagedResponse<ActorDto>
            {
                TotalCount = actors.Count(),

                Data = actors.Skip(toSkip).Take(search.PerPage.Value).Select(x => new ActorDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Biography = x.Biography,
                    Birthday = x.Born
                })
            .ToList(),

                CurrentPage = search.Page.Value,
                ItemsPerPage = search.PerPage.Value
            };


            return response;
            
        }
    }
}
