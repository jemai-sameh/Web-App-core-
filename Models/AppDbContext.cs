using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace WebApplicationCoreGLSI_B.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions
            <AppDbContext> options):base(options)
        {

        }
        public DbSet<Categorie> cats { get; set; }
        public DbSet<SousCategorie> sscats { get; set; }
        public DbSet<Produit> produit { get; set; }
    
        protected override void OnModelCreating(ModelBuilder model)
        {
            //Fluent API Entité
            model.Entity<Categorie>().ToTable("Categories");
            model.Entity<Categorie>()
                .Property(c => c.Name)
                .HasColumnName("CategorieName")
                .HasColumnType("varchar(20)")
                .HasDefaultValue("A");
            model.Entity<SousCategorie>()
            .Property(model => model.Name)
            .HasColumnName("SsCateg")
            .HasMaxLength(255);
            model.Entity<Categorie>()
                .HasData(new Categorie
                {
                    Id = 3,
                    Name = "CatFromAPIFluent"
                }
                );
            //Many to many Via API Fluent
            //model.Entity<SousCategorie>()
            //    .HasMany(t => t.produits)
            //    .WithMany(c => c.ssCategories);
            //string CatJson = System.IO.File.ReadAllText("Categorie.Json");
            //List<Categorie> categories = System.Text.Json.
            //JsonSerializer.Deserialize<List<Categorie>>(CatJson);
            ////Seed to categorie
            //foreach (Categorie c in categories)
            //    model.Entity<Categorie>()
            //    .HasData(c);


        }
    
    }
}
