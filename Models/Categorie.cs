using System.ComponentModel.DataAnnotations;

namespace WebApplicationCoreGLSI_B.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        //public int Id { get; set; }
        [Display(Name = "Name of Category")]
        public string Name { get; set; } 
    }
}
