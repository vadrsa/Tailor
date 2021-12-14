using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Tailor;
using WebApp.Tailoring;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITailor _tailor;
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ITailor tailor, ILogger<IndexModel> logger)
        {
            _tailor = tailor;
            _logger = logger;
        }

        public void OnGet()
        {
            bool allowTest = _tailor.Compile(AppRuleRepository.AllowTest.Name);
        }
    }
}