namespace practice_web_apis.Middlewares
{
    public class ExceptionsHandler
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionsHandler> _logger;

        public ExceptionsHandler(RequestDelegate next, ILogger<ExceptionsHandler> logger)
        {
            _next = next;
            _logger = logger;
        }

    }
}
