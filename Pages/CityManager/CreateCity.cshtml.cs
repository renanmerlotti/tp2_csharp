using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace questao1.Pages.CityManager
{
    public class CreateCityModel : PageModel
    {
        [BindProperty]
        public InputModel Input { get; set; } = new InputModel();

        public class InputModel
        {
            [Required(ErrorMessage = "O nome da cidade e obrigatorio")]
            [MinLength(3, ErrorMessage = "Deve ter no minimo 3 letras")]
            public string CityName { get; set; }
        }

        public void OnGet() { }

        public void OnPost() { }
    }
}
