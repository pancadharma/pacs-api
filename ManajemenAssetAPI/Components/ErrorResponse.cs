using System.Collections.Generic;

namespace Mahas.Components
{
    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }
        public ErrorResponse(List<string> errors, object attachment = null)
        {
            Message = string.Join(", ", errors);
            this.Errors = errors;
            this.Attachment = attachment;
        }

        public ErrorResponse(string message, List<string> errors = null, object attachment = null)
        {
            Message = message;
            Errors = errors ?? new List<string>() 
            {
                message
            };
            Attachment = attachment;
        }

        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public object Attachment { get; set; }
    }
}
