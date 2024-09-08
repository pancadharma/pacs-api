using AutoMapper;
using BankDarahAPI.Repository;
using pacsapi.Models;
using static System.Collections.Specialized.BitVector32;
using System.Data.SqlClient;
using Dapper;

namespace pacsapi.Repository
{
    public class ResultRepository : BaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public ResultRepository(string connectionString, IMapper mapper, IConfiguration configuration) : base(connectionString, mapper, configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<DataResultModelList<ResultModel>> ResultGet(string accession_Number)
        {
            using var conn = new SqlConnection(_connString);

            var result = await conn.QueryAsync<ResultModel>($"SELECT * FROM PACS_Get_Data('{accession_Number}')");

            var totalCount = result.Count();

            var data = new DataResultModelList<ResultModel>(totalCount, result, true);

            return data;

        }
    }
}
