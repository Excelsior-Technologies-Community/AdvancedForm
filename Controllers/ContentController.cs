using Microsoft.AspNetCore.Mvc;
using AdvancedForm.Data;
using AdvancedForm.Models;
using Microsoft.EntityFrameworkCore;

namespace AdvancedForm.Controllers
{
    public class ContentController : Controller
    {
        private readonly AppDbContext _db;
        private readonly IWebHostEnvironment _env;

        public ContentController(AppDbContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }

        public IActionResult Index()
        {
            var items = _db.ContentItems
                .OrderBy(x => x.Sequence)
                .ToList();

            return View(items);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(ContentItem model)
        {
            if (!ModelState.IsValid)
            {
                foreach (var m in ModelState)
                {
                    if (m.Value.Errors.Count > 0)
                    {
                        Console.WriteLine($"{m.Key}: {m.Value.Errors[0].ErrorMessage}");
                    }
                }
                return View(model);
            }

            model.Sequence = _db.ContentItems.Any()
                ? _db.ContentItems.Max(x => x.Sequence) + 1
                : 1;

            _db.ContentItems.Add(model);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }



        [HttpPost]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("File missing");

            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(uploads, fileName);

            using var fs = new FileStream(filePath, FileMode.Create);
            file.CopyTo(fs);

            return Json(new { success = true, fileName });
        }

        [HttpPost]
        [IgnoreAntiforgeryToken]
        public IActionResult UploadCroppedImage([FromBody] ImageCropRequest request)
        {
            Console.WriteLine("UploadCroppedImage HIT");

            if (request == null || string.IsNullOrEmpty(request.ImageBase64))
            {
                Console.WriteLine("ImageBase64 missing");
                return BadRequest("Image data missing");
            }

            var uploads = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
                Directory.CreateDirectory(uploads);

            var bytes = Convert.FromBase64String(
                request.ImageBase64.Replace("data:image/png;base64,", "")
            );

            var fileName = Guid.NewGuid() + ".png";
            var path = Path.Combine(uploads, fileName);

            System.IO.File.WriteAllBytes(path, bytes);

            Console.WriteLine("Image saved: " + fileName);

            return Json(new { path = "/uploads/" + fileName });
        }



        [HttpPost]
        public IActionResult SaveOrder(int[] ids)
        {
            for (int i = 0; i < ids.Length; i++)
            {
                var item = _db.ContentItems.Find(ids[i]);
                if (item != null)
                    item.Sequence = i + 1;
            }

            _db.SaveChanges();
            return Ok();
        }
    }
}
