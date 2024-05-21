using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace FileUploadExample.Controllers
{
    public class UploadContoller : Controller
    {
        private readonly IWebHostEnvironment _environment;

        public UploadContoller(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // Dosya yükleme formunu görüntülemek için action
        public IActionResult Index()
        {
            return View();
        }

        // Dosya yükleme işlemini işleyen action
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
                var uniqueFileName = Path.GetRandomFileName();
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
