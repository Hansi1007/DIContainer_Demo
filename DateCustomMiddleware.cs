namespace DIContainer_Demo
{
    public class DateCustomMiddleware
    {
        public const string ContextItemsKey = nameof(ContextItemsKey);

        private readonly RequestDelegate _next;
        private readonly ILogger<DateCustomMiddleware> _logger;

        public DateCustomMiddleware(RequestDelegate next, ILogger<DateCustomMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, IDateTime dateTime)
        {
            await Task.Delay(TimeSpan.FromSeconds(10)).ConfigureAwait(false);

            var date = dateTime.GetDate();

            context.Items.Add(ContextItemsKey, date);

            var logMessage = $"Middleware: The Date from Time is {date}";

            _logger.LogInformation(logMessage);

            await _next(context);
        }
    }
}
