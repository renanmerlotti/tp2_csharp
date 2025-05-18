using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace questao1.Pages.CountryManager
{
    public class CreateCountryModel : PageModel
    {
        public class InputModel
        {
            [Required(ErrorMessage = "Nome do pais e obrigatorio")]
            public string CountryName { get; set; }

            [Required(ErrorMessage = "Codigo do pais e obrigatorio")]
            [StringLength(2, MinimumLength = 2,
                ErrorMessage = "O codigo deve ter exatamente 2 caracteres")]
            public string CountryCode { get; set; }
        }

        [BindProperty]
        public List<InputModel> Countries { get; set; }

        public List<Country> SubmittedCountries { get; set; }

        public void OnGet()
        {
            Countries = new List<InputModel>(new InputModel[5]);
        }

        public void OnPost()
        {
            foreach (var (country, index) in Countries.Select((c, i) => (c, i)))
            {
                if (!string.IsNullOrWhiteSpace(country.CountryName) &&
                    !string.IsNullOrWhiteSpace(country.CountryCode) &&
                    char.ToUpper(country.CountryName[0]) != char.ToUpper(country.CountryCode[0]))
                {
                    ModelState.AddModelError($"Countries[{index}].CountryCode",
                        "A primeira letra do codigo deve ser igual a primeira letra do nome");
                }
            }

            if (ModelState.IsValid)
            {
                SubmittedCountries = Countries
                    .Where(c => !string.IsNullOrWhiteSpace(c.CountryName))
                    .Select(c => new Country
                    {
                        CountryName = c.CountryName,
                        CountryCode = c.CountryCode
                    })
                    .ToList();
            }
        }

        public class Country
        {
            public string CountryName { get; set; }
            public string CountryCode { get; set; }
        }
    }
}
