using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIContainer_Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IDateTime _date ;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(IDateTime date, ILogger<IndexModel> logger)
        {
            _date = date;
            _logger = logger;   
        }

        public string DateFromDependency { get; set; }

        public string DateFromMiddleware { get; set; }

        public void OnGet()
        {
            if (HttpContext.Items.TryGetValue(DateCustomMiddleware.ContextItemsKey,
                out var mwDate) && mwDate is string contextItemsKey)
            {
                DateFromMiddleware = contextItemsKey;
            }
            _logger.LogInformation("Middleware value {MV}",
                        DateCustomMiddleware.ContextItemsKey?.ToString() ?? "Middleware value not set!");

            var date = _date.GetDate();
            DateFromDependency = date;
        }
    }
}