using Mahas.Components;
using pacsapi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace pacsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly RepositoryWrapper _repository;

        public BaseController(RepositoryWrapper repository)
        {
            _repository = repository;
        }

        protected ActionResult ValidationError()
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors).Select(x => x.ErrorMessage);

            var errorResponse = new ErrorResponse(allErrors.ToList());

            return BadRequest(errorResponse);
        }

        protected ActionResult ValidationError(FluentValidation.Results.ValidationResult validationResult)
        {
            var errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();

            var errorResponse = new ErrorResponse(errors);

            return BadRequest(errorResponse);
        }
    }
}