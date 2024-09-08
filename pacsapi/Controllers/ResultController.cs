using Mahas.Components.CustomExceptions;
using Mahas.Helpers;
using pacsapi.Models;
using pacsapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace pacsapi.Controllers
{
    [ApiKey]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : BaseController
    {
        private readonly RepositoryWrapper _repository;
        public ResultController(RepositoryWrapper repository) : base(repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<DataResultModel<ResultModel>>> Result(string accession_Number)
        {
            var result = await _repository.Result.ResultGet(accession_Number);

            if (result.TotalCount == 0)
            {
                return BadRequest("Data tidak ditemukan");
            }
            return Ok(result);
        }

    }
}
