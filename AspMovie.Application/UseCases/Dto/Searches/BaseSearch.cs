

namespace AspMovie.Application.UseCases.Dto.Searches
{
    public class BaseSearch
    {
        public string Keyword { get; set; }
    }

    public class PagedSearch
    {
        public int? PerPage { get; set; } = 20;
        public int? Page { get; set; } = 1;
    }

    public class BasePagedSearch : PagedSearch
    {
        public string Keyword { get; set; }

    }
}
