using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIContainer_Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string Date { get; set; } = string.Empty;        
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var _shortDate = new ShortDate();
            var date = _shortDate.GetDate();
            Date = date;
            _logger.LogInformation("IndexModel OnGet Date: " + Date);
        }
    }
}