using WebApplicationCoreGLSI_B.Models;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSI_B.ServicesContracts;

namespace WebApplicationCoreGLSI_B.Services
{
    public class SousCategorieService : ISousCategorieService
    {
        private readonly AppDbContext _context;
        public SousCategorieService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<SousCategorie> Create(SousCategorie c)
        {
            _context.sscats.Add(c);
            await _context.SaveChangesAsync();
            return c;
        }

        public void Delete(int Id)
        {
            var cat = _context.sscats.Find(Id);
            /*  var sscat = _context.sscats.Where(s => s.categorieId == Id).ToList();
              foreach (var item in sscat)
              {
                  _context.sscats.Remove(item);
                  _context.SaveChanges();
              }*/
            _context.sscats.Remove(cat);
            _context.SaveChanges();
        }

        public SousCategorie Edit(int Id, SousCategorie c)
        {
            var catInDb = _context.cats.Find(Id);

            _context.cats.Update(catInDb);
            _context.SaveChanges();
            return c;

        }

        public async Task<ICollection<SousCategorie>> GetAll()
        {
            return await _context.sscats.Include(c=>c.categorie).ToListAsync();
        }
        public IEnumerable<SousCategorie> GetSousCategorieByCategorieName(String name)
        {
            var sscatName = _context.sscats
            .Where(c => c.categorie.Name == name)
            .ToList();
            return sscatName;
        }

        public IEnumerable<SousCategorie> GetSousCategorieOrderBy()
        {
            var sscatName = _context.sscats
                .OrderBy(c => c.categorie.Name)
            .ToList();
            return sscatName;
        }

    }
}
