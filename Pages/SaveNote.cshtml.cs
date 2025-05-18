using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace questao1.Pages
{
    public class SaveNoteModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public SaveNoteModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public class InputModel
        {
            [Required(ErrorMessage = "O conteudo da nota e obrigatorio")]
            public string Content { get; set; }
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string SavedFileName { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            SavedFileName = $"note-{timestamp}.txt";
            var filePath = Path.Combine(_env.WebRootPath, "files", SavedFileName);

            Directory.CreateDirectory(Path.Combine(_env.WebRootPath, "files"));
            await System.IO.File.WriteAllTextAsync(filePath, Input.Content);

            return Page();
        }
    }
}
