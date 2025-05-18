using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace questao1.Pages.CityManager
{
    public class CityDetailsModel : PageModel
    {
        public List<string> Cities { get; } = new List<string> { "Rio", "São Paulo", "Brasília" };

        public void OnGet()
        {
        }
    }
}
