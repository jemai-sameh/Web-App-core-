using Microsoft.EntityFrameworkCore;
using WebApplicationCoreGLSI_B.Models;

namespace WebApplicationCoreGLSI_B.ServicesContracts
{
    public interface ISousCategorieService
    {
        Task<ICollection<SousCategorie>> GetAll();
        //get all sous categorie by cat name
       IEnumerable<SousCategorie> GetSousCategorieByCategorieName(String name);
        IEnumerable<SousCategorie> GetSousCategorieOrderBy();



        Task<SousCategorie> Create(SousCategorie c);
        SousCategorie Edit(int Id, SousCategorie c);
        void Delete(int Id);
    }
}
