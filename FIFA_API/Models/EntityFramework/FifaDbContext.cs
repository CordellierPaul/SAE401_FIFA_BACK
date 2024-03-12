using Microsoft.EntityFrameworkCore;
using TP4.Models.EntityFramework;

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

            //ForeignKey Devis
            modelBuilder.Entity<Devis>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Devis>()
                .HasOne(p => p.Produit)
                .WithMany()
                .HasForeignKey(p => p.ProduitId)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Film
            modelBuilder.Entity<Film>()
                .HasOne(p => p.Media)
                .WithMany()
                .HasForeignKey(p => p.Url)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey FormulaireAide
            modelBuilder.Entity<FormulaireAide>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<FormulaireAide>()
               .HasOne(p => p.Action)
               .WithMany()
               .HasForeignKey(p => p.NumAction)
               .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Image
            modelBuilder.Entity<Image>()
                .HasOne(p => p.Media)
                .WithMany()
                .HasForeignKey(p => p.Url)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey ImageJoueur
            modelBuilder.Entity<ImageJoueur>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.Url)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImageJoueur>()
                .HasOne(p => p.Joueur)
                .WithMany()
                .HasForeignKey(p => p.IdJoueur)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey ImageVariante
            modelBuilder.Entity<ImageVariante>()
                .HasOne(p => p.Image)
                .WithMany()
                .HasForeignKey(p => p.Url)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImageVariante>()
                .HasOne(p => p.VarianteProduitIdProduit)
                .WithMany()
                .HasForeignKey(p => p.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ImageVariante>()
               .HasOne(p => p.VarianteProduitIdCouleur)
               .WithMany()
               .HasForeignKey(p => p.IdCouleur)
               .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey InfosBancaires
            modelBuilder.Entity<InfosBancaires>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Joueur
            modelBuilder.Entity<Joueur>()
                .HasOne(p => p.Ville)
                .WithMany()
                .HasForeignKey(p => p.IdVille)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Joueur>()
                .HasOne(p => p.Club)
                .WithMany()
                .HasForeignKey(p => p.IdClub)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Joueur>()
                .HasOne(p => p.Poste)
                .WithMany()
                .HasForeignKey(p => p.NumPoste)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey JoueurTheme
            modelBuilder.Entity<JoueurTheme>()
                .HasOne(p => p.Theme)
                .WithMany()
                .HasForeignKey(p => p.NumTheme)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<JoueurTheme>()
                .HasOne(p => p.Joueur)
                .WithMany()
                .HasForeignKey(p => p.IdJoueur)
                .OnDelete(DeleteBehavior.Restrict);

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

            //ForeignKey Utilisateur
            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.Adresse)
                .WithMany()
                .HasForeignKey(p => p.IdAdresse)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.Compte)
                .WithMany()
                .HasForeignKey(p => p.IdCompte)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.Langue)
                .WithMany()
                .HasForeignKey(p => p.NumLangue)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.PaysFavoriNavigation)
                .WithMany()
                .HasForeignKey(p => p.PaysFavori)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.PaysNaissanceNavigation)
                .WithMany()
                .HasForeignKey(p => p.PaysNaissance)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Utilisateur>()
                .HasOne(p => p.Monnaie)
                .WithMany()
                .HasForeignKey(p => p.NumMonnaie)
                .OnDelete(DeleteBehavior.Restrict);


            //ForeignKey VarianteProduit
            modelBuilder.Entity<VarianteProduit>()
                .HasOne(p => p.Produit)
                .WithMany()
                .HasForeignKey(p => p.IdProduit)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VarianteProduit>()
                .HasOne(p => p.Couleur)
                .WithMany()
                .HasForeignKey(p => p.IdCouleur)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Vote
            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Utilisateur)
                .WithMany()
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Theme)
                .WithMany()
                .HasForeignKey(p => p.NumTheme)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Vote>()
                .HasOne(p => p.Joueur)
                .WithMany()
                .HasForeignKey(p => p.IdJoueur)
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
