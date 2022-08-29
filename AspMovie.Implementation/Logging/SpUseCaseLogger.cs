using AspMovie.Application.Logging;
using Microsoft.Data.SqlClient;
using Dapper;
using System.Collections.Generic;


namespace Implementation.Logging
{
    public class SpUseCaseLogger : IUseCaseLogger
    {
        private string _connString;

        public SpUseCaseLogger(string connString)
        {
            _connString = connString;
        }

        public IEnumerable<UseCaseLog> GetLogs(UseCaseLogSearch search)
        {
            var connection = new SqlConnection(_connString);

            return connection.Query<UseCaseLog>(
                "GetUseCaseLogs",
                new
                {
                    dateFrom = search.DateFrom,
                    dateTo = search.DateTo,
                    user = search.Username,
                    useCaseName = search.UseCaseName
                },
                commandType: System.Data.CommandType.StoredProcedure);
        }

        public void Log(UseCaseLog log)
        {
            var connection = new SqlConnection(_connString);

            connection.Query("AddNewLogRecord",
                             new
                             {
                                 useCaseName = log.UseCaseName,
                                 username = log.User,
                                 userId = log.UserId,
                                 executionTIme = log.ExecutionDateTime,
                                 data = log.Data,
                                 isAuthorized = log.IsAuthorized
                             },
                             commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
