using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.Models.DTO;
using WebApplicationCoreGLSI_B.ServicesContracts;

namespace WebApplicationCoreGLSI_B.Controllers.APIControllers
{
    
    public class CategorieController : CustomController
    {
        private readonly ICategorieService categorieService;
        public CategorieController(ICategorieService categorieService)
        {
            this.categorieService = categorieService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCat()
        {
            var categories = await categorieService.GetAll();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCat(CategorieDto c)
        {
                var cat = await categorieService.Create(c);
            return Ok(cat);
        }
        [HttpPut]
        public IActionResult EditCat(int Id, CategorieDto c)
        {
            var cat = categorieService.Edit(Id, c);
            return Ok(cat);
        }
        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            categorieService.Delete(Id);
            return Ok();
        }
    }
}
