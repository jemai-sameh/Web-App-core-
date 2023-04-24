using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.Models.DTO;
using WebApplicationCoreGLSI_B.ServicesContracts;

namespace WebApplicationCoreGLSI_B.Services
{
    public class CategorieService : ICategorieService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        public CategorieService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CategorieDto> Create(CategorieDto c)
        {
            var cat = _mapper.Map<CategorieDto, Categorie>(c);

            _context.cats.Add(cat);
            await _context.SaveChangesAsync();
            return _mapper.Map<Categorie, CategorieDto>(cat);
        }

        public void Delete(int Id)
        {
            var cat = _context.cats.Find(Id);
          /*  var sscat = _context.sscats.Where(s => s.categorieId == Id).ToList();
            foreach (var item in sscat)
            {
                _context.sscats.Remove(item);
                _context.SaveChanges();
            }*/
            _context.cats.Remove(cat);
            _context.SaveChanges();
        }

        public CategorieDto Edit(int Id, CategorieDto c)

        {
            var cat = _mapper.Map<CategorieDto, Categorie>(c);

            var catInDb=  _context.cats.Find(Id);

            _context.cats.Update(cat);
            _context.SaveChanges();
            return c;

        }

        public async Task<ICollection<CategorieDto>> GetAll()
        {
            //execution déferé 
            /*  synataxe query
             var t =  (from c in _context.cats
                select c).ToList();
              //dot notation synataxe émidiate
            // var x=_context.cats.ToList();
            //is the same 
            var t1 =  from c in _context.cats
                select c;
            forech(var item in t1){
                //affichage
            }
            */
            var cats =  await _context.cats.ToListAsync();
            return  _mapper.Map<List<CategorieDto>>(cats);
        }
    }
}
