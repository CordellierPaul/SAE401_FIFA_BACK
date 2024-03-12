using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.EntityFramework
{
    public partial class FifaDbContext : DbContext
    {
        public FifaDbContext() { }

        public FifaDbContext(DbContextOptions<FifaDbContext> options)
            : base(options)
        { }

        public virtual DbSet<Action> Action { get; set; } = null!;
        //public virtual DbSet<...> ... { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Il faudra donner des infos sur la base ici
            modelBuilder.Entity<Reglement>(entity =>
            {
                entity.Property(e => e.DateReglement).HasDefaultValueSql("now()");
            });

            //ForeignKey Produit
            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Pays)
                .WithMany()
                .HasForeignKey(p => p.NumPays)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Categorie)
                .WithMany()
                .HasForeignKey(p => p.NumCategorie)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Competition)
                .WithMany()
                .HasForeignKey(p => p.IdCompetition)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Genre)
                .WithMany()
                .HasForeignKey(p => p.NumGenre)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Produit_Similaire

            modelBuilder.Entity<Produit_Similaire>()
                .HasOne(p => p.PremierProduit)
                .WithMany()
                .HasForeignKey(p => p.ProduitUn)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Produit_Similaire>()
                .HasOne(p => p.DeuxiemeProduit)
                .WithMany()
                .HasForeignKey(p => p.ProduitDeux)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Reglement
            modelBuilder.Entity<Reglement>()
                .HasOne(p => p.Commande)
                .WithMany()
                .HasForeignKey(p => p.NumCommande)
                .OnDelete(DeleteBehavior.Restrict);
            OnModelCreatingPartial(modelBuilder);


            //ForeignKey Remporte
            modelBuilder.Entity<Remporte>()
                .HasOne(p => p.Joueur)
                .WithMany()
                .HasForeignKey(p => p.IdJoueur)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Remporte>()
                .HasOne(p => p.Trophee)
                .WithMany()
                .HasForeignKey(p => p.NumTrophee)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Sous_Categorie
            modelBuilder.Entity<Sous_Categorie>()
                .HasOne(p => p.ObjCategorieEnfant)
                .WithMany()
                .HasForeignKey(p => p.CategorieEnfant)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Sous_Categorie>()
                .HasOne(p => p.ObjCategorieParent)
                .WithMany()
                .HasForeignKey(p => p.CategorieParent)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Ville
            modelBuilder.Entity<Ville>()
                .HasOne(p => p.Pays)
                .WithMany()
                .HasForeignKey(p => p.NumPays)
                .OnDelete(DeleteBehavior.Restrict);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
