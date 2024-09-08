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

        [HttpPost]
        public async Task<ActionResult<DataResultModel<OrderPost>>> OrderPost(OrderPost model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Order.OrderInsert(model);

            return Ok(result);
        }

        [HttpPut]
        [Route("{accession_Number}")]
        public async Task<ActionResult<DataResultModel<OrderPut>>> OrderPut([FromRoute] string accession_Number, OrderPut model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _repository.Order.OrderPut(accession_Number, model);

            return Ok(result);
        }

    }
}
