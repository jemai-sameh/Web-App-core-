using Microsoft.AspNetCore.Mvc;
using WebApplicationCoreGLSI_B.Models;
using WebApplicationCoreGLSI_B.Services;
using WebApplicationCoreGLSI_B.ServicesContracts;

namespace WebApplicationCoreGLSI_B.Controllers.APIControllers
{
    public class SousCategorieController : CustomController
    {
        private readonly ISousCategorieService categorieService;
        public SousCategorieController(ISousCategorieService categorieService)
        {
            this.categorieService = categorieService;
        }

        [HttpGet]
        [Route("{name}")]
        public IActionResult Get(string name)
        {
            var c = categorieService.GetSousCategorieByCategorieName(name);
            return Ok(c);
        }
        [HttpGet]
        [Route("orderBy")]
        public IActionResult GetOrderBy()
        {
            var c = categorieService.GetSousCategorieOrderBy();
            return Ok(c);
        }
    }
