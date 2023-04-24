using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.Models.DTO;

namespace WebApplicationCoreGLSI_B.ServicesContracts
{
    public interface ICategorieService
    {
        //Signature de la méthode permettant de récupérer la liste de catégories
        Task<ICollection<CategorieDto>> GetAll();
        Task<CategorieDto> Create(CategorieDto c);
        CategorieDto Edit(int Id, CategorieDto c);
        void Delete(int Id);
    }
}
