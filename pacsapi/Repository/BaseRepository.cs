using AutoMapper;
using Dapper;
using Mahas.Components;
using System.Data.SqlClient;

namespace BankDarahAPI.Repository
{
    public class BaseRepository
    {
        public enum OrderByType
        {
            ASC,
            DESC
        }

        protected readonly string _connString;

        protected readonly IMapper _mapper;


        private readonly IConfiguration _configuration;
        public BaseRepository(string connectionString, IMapper mapper, IConfiguration configuration)
        {
            _connString = connectionString;
            _mapper = mapper;
            _configuration = configuration;
        }

        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BaseRepository(string connectionString)
        {
            _connString = connectionString;
        }


        protected async Task<PaginationResult<T>> GetPaginationAsync<T>(string query, string orderBy, OrderByType orderByType, PaginationFilter filter, Dictionary<string, object> parameters = null) where T : new()
        {
            var pageIndex = filter.PageIndex;
            var pageSize = filter.PageSize;

            var countQuery = $"SELECT COUNT (*) FROM ({query}) ALIAS";

            var paginationQuery = $@"
                    SELECT
                        ROW_NUMBER() OVER (ORDER BY {orderBy} {orderByType}) AS RowNumber,
                        *
                    FROM ({query}) AS ALIAS
                ";

            paginationQuery = $@"
                    WITH Alias AS ({paginationQuery})
                    SELECT TOP {pageSize}
                        *
                    FROM
                        Alias
                    WHERE
                        RowNumber > (@pageIndex * @pageSize)
                    ";

            parameters.Add("pageIndex", pageIndex);
            parameters.Add("pageSize", pageSize);

            using var conn = new SqlConnection(_connString);

            var count = await conn.ExecuteScalarAsync<int>(countQuery, parameters);

            var result = await conn.QueryAsync<T>(paginationQuery, parameters);

            return new PaginationResult<T>(count, result, filter);
        }

        protected string ToWhere(List<string> wheres)
        {
            if (wheres.Count == 0) return "";
            var where = string.Join(" AND ", wheres);
            return "WHERE " + where;
        }
    }
}
