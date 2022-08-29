

using AspMovie.Application.Logging;
using System.Collections.Generic;

namespace AspMovie.Application.UseCases.Queries
{
    public interface IGetUseCaseLogsQuery : IQuery<UseCaseLogSearch, IEnumerable<UseCaseLog>>
    {

    }
}
