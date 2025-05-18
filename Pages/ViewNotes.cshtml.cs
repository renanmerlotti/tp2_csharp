using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace questao1.Pages
{
    public class ViewNotesModel : PageModel
    {
        private readonly IWebHostEnvironment _env;

        public ViewNotesModel(IWebHostEnvironment env)
        {
            _env = env;
        }

        public IEnumerable<FileInfo> NoteFiles { get; set; }

        public void OnGet()
        {
            var filesDir = Path.Combine(_env.WebRootPath, "files");
            var dirInfo = new DirectoryInfo(filesDir);
            NoteFiles = dirInfo.Exists ? dirInfo.GetFiles("*.txt") : new FileInfo[0];
        }
    }
}
