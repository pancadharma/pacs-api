using Mahas.Components.CustomExceptions;
using Mahas.Helpers;
using pacsapi.Models;
using pacsapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pacsapi.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseController
    {
        private readonly RepositoryWrapper _repository;
        public OrderController(RepositoryWrapper repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("List")]
        public async Task<DataResultModelList<BarangModelListAndGetByKodeBarang>> GetListBarang()
        {

            var result = await _repository.Order.GetDataBarangList();

            return result;
        }


        [HttpPut]

        public async Task<ActionResult<DataResultModel<UpdateBarang>>> UpdateBarang(string KodeBarang, int PenerimaanId)
        {
            var result = await _repository.Order.UpdateDataBarang(KodeBarang, PenerimaanId);

            if(result.TotalCount == 0)
            {
                return BadRequest("Invalid Value Parameter");
            }

            return Ok(result);
        }
    }
}
