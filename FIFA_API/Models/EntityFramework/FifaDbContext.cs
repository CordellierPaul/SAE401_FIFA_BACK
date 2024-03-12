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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
