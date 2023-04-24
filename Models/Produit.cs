namespace WebApplicationCoreGLSI_B.Models
{
    public class Produit
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? ImageFile { get; set; }
        public DateTime? DateAjoutProduit { get; set; }
        public ICollection<SousCategorie>? ssCategories { get; set; }
    }
}
