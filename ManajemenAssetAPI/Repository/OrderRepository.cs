using AutoMapper;
using BankDarahAPI.Repository;
using pacsapi.Models;
using static System.Collections.Specialized.BitVector32;
using System.Data.SqlClient;
using Dapper;

namespace pacsapi.Repository
{
    public class OrderRepository : BaseRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        public OrderRepository(string connectionString, IMapper mapper, IConfiguration configuration) : base(connectionString, mapper, configuration)
        {
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<DataResultModel<BarangModelListAndGetByKodeBarang>> GetDataBarangByKodeBarang(string KodeBarang)
        {
            using var conn = new SqlConnection(_connString);

            var result = await conn.QueryFirstOrDefaultAsync<BarangModelListAndGetByKodeBarang>("SELECT * FROM Aset_GetData_Barang(@KodeBarang)", new
            {
                KodeBarang = KodeBarang,
            });

            var totalCount = 0;

            if (result != null)
            {
                totalCount = 1;
            }
       
            var data = new DataResultModel<BarangModelListAndGetByKodeBarang>(totalCount, result);

            return data;

        }

        public async Task<DataResultModelList<BarangModelListAndGetByKodeBarang>> GetDataBarangList()
        {
            using var conn = new SqlConnection(_connString);

            var result = await conn.QueryAsync<BarangModelListAndGetByKodeBarang>("SELECT * FROM Aset_ListData_Barang()");

            var totalCount = result.Count();

            var data = new DataResultModelList<BarangModelListAndGetByKodeBarang>(totalCount, result);

            return data;

        }

        private async Task<int> UpdateDataBarangSP(string KodeBarang, int PenerimaanId)
        {
            using var connection = new SqlConnection(_connString);

            var result = await connection.ExecuteAsync("Aset_updatedatabarang", new
            {
                Penerimaan_ID = PenerimaanId,
                Kode_Barang = KodeBarang
            },

            commandType: System.Data.CommandType.StoredProcedure);

            return result;

        }

        public async Task<DataResultModel<UpdateBarang>> UpdateDataBarang(string KodeBarang, int PenerimaanId)
        {
            var result = await UpdateDataBarangSP(KodeBarang, PenerimaanId);

            var model = new UpdateBarang();

            model.Kode_Barang = result == 0 ? null : KodeBarang;
            model.Penerimaan_ID = result == 0  ? null : PenerimaanId;

            var data = new DataResultModel<UpdateBarang>(result, model);

            return data;
        }
    }
}
