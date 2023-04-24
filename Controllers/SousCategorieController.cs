using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.ServicesContracts;

namespace WebApplicationCoreGLSI_B.Controllers
{
    public class SousCategorieController : Controller
    {
        private readonly AppDbContext appDbContext;

        public SousCategorieController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public IActionResult Create()
        {
            var c = appDbContext.cats.ToList();
            ViewBag.Categories = c.Select(c
            => new SelectListItem()
            {
                Text = c.Name
            ,
                Value = c.Id.ToString()
            });
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SousCategorie sscat)
        {
            if (!ModelState.IsValid)
            {
                List<Categorie> cat = appDbContext.cats.ToList();
                //ViewBag est utilisé pour transférer des données temporaires (non inclus dans
                //le modèle) du contrôleur à la vue.
                ViewBag.Categories = cat.Select(c
                => new SelectListItem()
                {
                    Text = c.Name //texte à afficher de la selectList
                ,
                    Value = c.Id.ToString() //Valeur de la selectList
                });
                return View();
            }
           // sscats.Id = Guid.NewGuid();
            appDbContext.sscats.Add(sscat);
            appDbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View(appDbContext.sscats.Include(c=>c.categorie)
                .ToList());
        }
       
    }
}
