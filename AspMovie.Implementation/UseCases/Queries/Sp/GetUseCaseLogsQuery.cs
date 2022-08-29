using AspMovie.Application.Logging;
using AspMovie.Application.UseCases.Queries;
using FluentValidation;
using AspMovie.Implementation.Validators;
using System.Collections.Generic;

namespace AspMovie.Implementation.UseCases.Queries.Sp
{
    public class GetUseCaseLogsQuery : IGetUseCaseLogsQuery
    {
        public int Id => 10;

        public string Name => "Search use case logs";

        public string Description => "";

        private IUseCaseLogger _logger;
        private SearchUseCaseLogsValidator _validator;

        public GetUseCaseLogsQuery(IUseCaseLogger logger, SearchUseCaseLogsValidator validator)
        {
            _logger = logger;
            _validator = validator;
        }

        public IEnumerable<UseCaseLog> Execute(UseCaseLogSearch search)
        {
            _validator.ValidateAndThrow(search);
            return _logger.GetLogs(search);
        }
    }
}
