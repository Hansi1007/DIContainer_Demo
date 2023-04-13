using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DIContainer_Demo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IDate _shortDate;

        public string Date { get; set; } = string.Empty;        
        public IndexModel(IDate date, ILogger<IndexModel> logger)
        {
            _shortDate = date;
            _logger = logger;
            _logger.LogInformation("IndexModel with DI of IDate and ILogger: " + Date);
        }

        public void OnGet()
        {
            // We don't need to create an instance of ShortDate inside the method
            // var _shortDate = new ShortDate();
            var date = _shortDate.GetDate();
            Date = date;
            _logger.LogInformation("IndexModel OnGet Date: " + Date);
        }
    }
}