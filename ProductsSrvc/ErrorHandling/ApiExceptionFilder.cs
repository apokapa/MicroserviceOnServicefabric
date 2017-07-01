using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http.Filters;

namespace ProductsSrvc.ErrorHandling
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            ApiError apiError = null;
            context.Response = new HttpResponseMessage();
            if (context.Exception is ApiException)
            {
                // handle explicit 'known' API errors
                var ex = context.Exception as ApiException;
                context.Exception = null;
                apiError = new ApiError(ex.Message);
                //apiError.errors = ex.Errors;

                context.Response.StatusCode = (HttpStatusCode)ex.StatusCode;
            }
            else if (context.Exception is UnauthorizedAccessException)
            {
                apiError = new ApiError("Unauthorized Access");
                context.Response.StatusCode = HttpStatusCode.Unauthorized;

                // handle logging here
            }
            else
            {
                // Unhandled errors
                //#if !DEBUG
                //var msg = "An unhandled error occurred.";                
                //string stack = null;
                //#else
                var msg = context.Exception.GetBaseException().Message;
                string stack = context.Exception.StackTrace;
                //#endif

                apiError = new ApiError(msg);
                apiError.detail = stack;

                context.Response.StatusCode = HttpStatusCode.InternalServerError;

                // handle logging here
            }

            // always return a JSON result
            var newContent = new ObjectContent<ApiError>(apiError, new JsonMediaTypeFormatter());
            context.Response.Content = newContent;

            base.OnException(context);
        }
    }



    public class ApiException : Exception
    {
        public int StatusCode { get; set; }

        //public ValidationErrorCollection Errors { get; set; }

        public ApiException(string message, int statusCode = 500 /*ValidationErrorCollection errors = null*/) : base(message)
        {
            StatusCode = statusCode;
            //Errors = errors;
        }

        public ApiException(Exception ex, int statusCode = 500) : base(ex.Message)
        {
            StatusCode = statusCode;
        }
    }
}
