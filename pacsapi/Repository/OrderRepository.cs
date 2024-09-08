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

        public async Task<DataResultModel<OrderPost>> OrderInsert(OrderPost model)
        {
            using var connection = new SqlConnection(_connString);

            // Parameter yang akan dikirim ke stored procedure sesuai dengan properti pada model OrderPost
            var parameters = new
            {
                Accession_Number = model.Accession_Number,
                Modality = model.Modality,
                Institution_Name = model.Institution_Name,
                Ref_Physician_Name = model.Ref_Physician_Name,
                Patient_Name = model.Patient_Name,
                Patient_ID = model.Patient_ID,
                Patient_Birth_Date = model.Patient_Birth_Date,
                Patient_Age = model.Patient_Age,
                Patient_Sex = model.Patient_Sex,
                Patient_Weight = model.Patient_Weight,
                Requesting_Physician = model.Requesting_Physician,
                Req_Proc_Desc = model.Req_Proc_Desc,
                Admission_ID = model.Admission_ID,
                Sch_Station_AE_Title = model.Sch_Station_AE_Title,
                Sch_Station_Name = model.Sch_Station_Name,
                Sch_Proc_Step_Start_Date = model.Sch_Proc_Step_Start_Date,
                Sch_Proc_Step_Start_Time = model.Sch_Proc_Step_Start_Time,
                Sch_Perf_Physician_Name = model.Sch_Perf_Physician_Name,
                Sch_Proc_Step_Desc = model.Sch_Proc_Step_Desc,
                Sch_Proc_Step_ID = model.Sch_Proc_Step_ID,
                Sch_Proc_Step_Location = model.Sch_Proc_Step_Location,
                Req_Proc_ID = model.Req_Proc_ID,
                Reason_for_the_Req_Proc = model.Reason_for_the_Req_Proc,
                Req_Proc_Priority = model.Req_Proc_Priority,
                Order_Status = model.Order_Status,
                Error_Desc = model.Error_Desc,
                IPD_Field1 = model.IPD_Field1,
                IPD_Field2 = model.IPD_Field2,
                IPD_Field3 = model.IPD_Field3,
                IPD_Field4 = model.IPD_Field4,
                IPD_Field5 = model.IPD_Field5,
                IPD_Field6 = model.IPD_Field6,
                IPD_Field7 = model.IPD_Field7,
                IPD_Field8 = model.IPD_Field8,
                IPD_Field9 = model.IPD_Field9,
                IPD_Field10 = model.IPD_Field10,
                IPD_Field11 = model.IPD_Field11,
                IPD_Field12 = model.IPD_Field12,
                IPD_Field13 = model.IPD_Field13,
                IPD_Field14 = model.IPD_Field14,
                IPD_Field15 = model.IPD_Field15
            };

            // Menjalankan stored procedure Insert_HIS_ORDER
            var result = await connection.ExecuteAsync(
                "Insert_HIS_ORDER",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            // Mengembalikan hasil operasi
            return new DataResultModel<OrderPost>(
                totalcount: 1, // Sesuaikan dengan jumlah item yang diinginkan
                data: model,
                success: result > 0 // Success jika hasil eksekusi lebih dari 0
            );
        }

        public async Task<DataResultModel<OrderPut>> OrderPut(string accession_Number, OrderPut model)
        {
            using var connection = new SqlConnection(_connString);

            // Parameter yang akan dikirim ke stored procedure sesuai dengan properti pada model OrderPost
            var parameters = new
            {
                Accession_Number = accession_Number,
                Modality = model.Modality,
                Institution_Name = model.Institution_Name,
                Ref_Physician_Name = model.Ref_Physician_Name,
                Patient_Name = model.Patient_Name,
                Patient_ID = model.Patient_ID,
                Patient_Birth_Date = model.Patient_Birth_Date,
                Patient_Age = model.Patient_Age,
                Patient_Sex = model.Patient_Sex,
                Patient_Weight = model.Patient_Weight,
                Requesting_Physician = model.Requesting_Physician,
                Req_Proc_Desc = model.Req_Proc_Desc,
                Admission_ID = model.Admission_ID,
                Sch_Station_AE_Title = model.Sch_Station_AE_Title,
                Sch_Station_Name = model.Sch_Station_Name,
                Sch_Proc_Step_Start_Date = model.Sch_Proc_Step_Start_Date,
                Sch_Proc_Step_Start_Time = model.Sch_Proc_Step_Start_Time,
                Sch_Perf_Physician_Name = model.Sch_Perf_Physician_Name,
                Sch_Proc_Step_Desc = model.Sch_Proc_Step_Desc,
                Sch_Proc_Step_ID = model.Sch_Proc_Step_ID,
                Sch_Proc_Step_Location = model.Sch_Proc_Step_Location,
                Req_Proc_ID = model.Req_Proc_ID,
                Reason_for_the_Req_Proc = model.Reason_for_the_Req_Proc,
                Req_Proc_Priority = model.Req_Proc_Priority,
                Order_Status = model.Order_Status,
                Error_Desc = model.Error_Desc,
                IPD_Field1 = model.IPD_Field1,
                IPD_Field2 = model.IPD_Field2,
                IPD_Field3 = model.IPD_Field3,
                IPD_Field4 = model.IPD_Field4,
                IPD_Field5 = model.IPD_Field5,
                IPD_Field6 = model.IPD_Field6,
                IPD_Field7 = model.IPD_Field7,
                IPD_Field8 = model.IPD_Field8,
                IPD_Field9 = model.IPD_Field9,
                IPD_Field10 = model.IPD_Field10,
                IPD_Field11 = model.IPD_Field11,
                IPD_Field12 = model.IPD_Field12,
                IPD_Field13 = model.IPD_Field13,
                IPD_Field14 = model.IPD_Field14,
                IPD_Field15 = model.IPD_Field15
            };

            // Menjalankan stored procedure Insert_HIS_ORDER
            var result = await connection.ExecuteAsync(
                "Update_HIS_ORDER",
                parameters,
                commandType: System.Data.CommandType.StoredProcedure
            );

            // Mengembalikan hasil operasi
            return new DataResultModel<OrderPut>(
                totalcount: 1, // Sesuaikan dengan jumlah item yang diinginkan
                data: model,
                success: result > 0 // Success jika hasil eksekusi lebih dari 0
            );
        }
    }
}
