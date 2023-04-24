using System.ComponentModel.DataAnnotations;

namespace WebApplicationCoreGLSI_B.Models.DTO
{
    public class CategorieDto
    {
        public int Id { get; set; }
        //public int Id { get; set; }
        [Display(Name = "Name of Category")]
        public string Name { get; set; }
    }
}
