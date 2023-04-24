namespace WebApplicationCoreGLSI_B.Models
{
    public class SousCategorie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int categorieId { get; set; }
        public Categorie? categorie { get; set; }
        public ICollection<Produit>? produits { get; set; }
    }
}
