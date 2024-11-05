using Lab2.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab2.Web1.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string StudentName { get; set; }

        public void OnGet()
        {
            var db = new StudentDbContext();

            var student = db.Students.First();

            StudentName = student.Name;
        }
    }
}
