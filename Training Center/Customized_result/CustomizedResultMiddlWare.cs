using TrainingSystem.data.Exceptions;
using TrainingSystem.Shared.ErrorToReturn;

namespace Training_Center.Customized_result
{
    
        public class CustomExceptionMiddleWare
        {
            private readonly RequestDelegate next;


            public CustomExceptionMiddleWare(RequestDelegate Next)
            {
                next = Next;

            }
            public async Task Invoke(HttpContext context, ILogger<CustomExceptionMiddleWare> logger)
            {
                try
                {
                    await next.Invoke(context);
                    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                    {

                        var Response = new ErrorToReturn()
                        {
                            StatusCode = StatusCodes.Status404NotFound,
                            Message = $"this End Point {context.Request.Path} is Not Found"
                        };
                        await context.Response.WriteAsJsonAsync(Response);
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, ex.Message);
                    var Response = new ErrorToReturn()
                    {
                        Message = ex.Message
                    };

                    context.Response.StatusCode = ex switch
                    {
                        NotfoundEx _ => StatusCodes.Status404NotFound,
                        BadRequestException badreq => GetBadRequestErrors(badreq, Response),

                        _ => StatusCodes.Status500InternalServerError

                    };

                    Response.StatusCode = context.Response.StatusCode;



                    context.Response.ContentType = "application/json"; 



                    await context.Response.WriteAsJsonAsync(Response);

                }
            }

            private int GetBadRequestErrors(BadRequestException exception, ErrorToReturn response)
            {
                response.Errors = exception.Errors;
                return StatusCodes.Status400BadRequest;
            }
        }
    
}
