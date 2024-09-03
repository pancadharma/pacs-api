using Mahas.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;

namespace Mahas.Helpers
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (!context.ModelState.IsValid)
            {
                var errorList = context.ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToList();

                var response = new ErrorResponse("Validation Error", errorList);

                context.Result = new BadRequestObjectResult(response);
            }
        }
    }
}
