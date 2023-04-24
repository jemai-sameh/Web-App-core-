using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplicationCoreGLSI_B.Models;

namespace WebApplicationCoreGLSI_B.Controllers
{
    public class CategorieController : Controller
    {
        //CRUD pour categorie
        private readonly AppDbContext _context;
        public CategorieController(AppDbContext _context)
        {
            this._context = _context;

        }
        //Lister toutes les catégories
        public IActionResult Index()
        {
            var c = _context.cats.ToList();
            return View(c);
        }
        //[Route("DownloadFile")]
        //public IActionResult DowloadFile()
        //{
        //    byte[] bytes = System.IO.File
        //        .ReadAllBytes(@"C:\Users\TEK-UP\Desktop\Document.pdf");
        //    return File(bytes, "application/pdf");
        //}
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categorie c)
        {
            _context.cats.Add(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            var c = _context.cats.FirstOrDefault(c => c.Id == id);
            return View(c);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categorie c)
        {
            _context.cats.Update(c);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();
            var x = _context.cats.Find(id);
            _context.cats.Remove(x);
            _context.SaveChanges();
            return RedirectToAction(nameof
                (Index));
        }

        //[HttpPost]
        //[ActionName("Delete")]
        //public IActionResult DeleteConfirmed(int? id)
        //{
        //    var c = _context.cats.Find(id);
        //    if (c == null) return NotFound();
        //    _context.cats.Remove(c);
        //    _context.SaveChanges();
        //    return RedirectToAction(nameof(Index));
        //}
    }
}
