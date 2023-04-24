using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.Models.ViewModels;

namespace WebApplicationCoreGLSI_B.Controllers
{
    public class ProduitController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProduitController(AppDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Create()
        {
            return View();
        }
       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitVM model, IFormFile photo)
        {
            if (photo == null)
                return Content("File not uploaded");
            try
            {
                //Combine trois chaînes dans un seul path
                var path = Path.Combine(_environment.WebRootPath, "images",
                photo.FileName);
                //fournit un stream pour la lecture et ecriture dans un fichier
                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    photo.CopyTo(stream);
                    stream.Close();
                }
                
                //Mapping entre Model et ViewModel
                var produit = new Produit
                {
                    Id = new Guid(),
                    Name = model.produit.Name,
                    DateAjoutProduit = model.produit.DateAjoutProduit,
                    ImageFile = photo.FileName,
                };
                _context.Add(produit);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }
        public IActionResult Index()
        {
            return View(_context.produit.ToList());
        }
    }
}
