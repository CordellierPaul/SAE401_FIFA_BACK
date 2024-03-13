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
                .HasForeignKey(p => p.GenreId)
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
                .HasForeignKey(p => p.ProduitId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<VarianteProduit>()
                .HasOne(p => p.Coloris)
                .WithMany()
                .HasForeignKey(p => p.ColorisId)
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

            //ForeignKey AlbumImages
            modelBuilder.Entity<AlbumImage>(entity =>
            {
                entity.HasKey(e => new { e.IdAlbum, e.IdImage })
                    .HasName("pk_ali");

                entity.HasOne(d => d.AlbumNavigation)
                    .WithMany(p => p.LiensImages)
                    .HasForeignKey(d => d.IdAlbum)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_flm");

                entity.HasOne(d => d.ImageNavigation)
                    .WithMany(p => p.LiensAlbums)
                    .HasForeignKey(d => d.IdImage)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_not_utl");
            });

            #region Clés primaires d'entités

            modelBuilder.Entity<Action>()
                .HasKey(e => e.Id)
                .HasName("pk_act");

            modelBuilder.Entity<Activite>()
                .HasKey(e => e.Id)
                .HasName("pk_ati");

            modelBuilder.Entity<Adresse>()
                .HasKey(e => e.Id)
                .HasName("pk_adr");

            modelBuilder.Entity<Album>()
                .HasKey(e => e.Id)
                .HasName("pk_alb");

            modelBuilder.Entity<Anecdote>()
                .HasKey(e => e.Id)
                .HasName("pk_anc");

            modelBuilder.Entity<Article>()
                .HasKey(e => e.Id)
                .HasName("pk_art");

            modelBuilder.Entity<Blog>()
                .HasKey(e => e.Id)
                .HasName("pk_blg");

            modelBuilder.Entity<Caracteristique>()
                .HasKey(e => e.CaracteristiqueId)
                .HasName("pk_car");

            modelBuilder.Entity<Club>()
                .HasKey(e => e.ClubId)
                .HasName("pk_clb");

            modelBuilder.Entity<Coloris>()
                .HasKey(e => e.ColorisId)
                .HasName("pk_clr");

            modelBuilder.Entity<Commande>()
                .HasKey(e => e.CommandeId)
                .HasName("pk_cmd");

            modelBuilder.Entity<Commentaire>()
                .HasKey(e => e.CommentaireId)
                .HasName("pk_com");

            modelBuilder.Entity<Competition>()
                .HasKey(e => e.CompetitionId)
                .HasName("pk_cpn");

            modelBuilder.Entity<Compte>()
                .HasKey(e => e.CompteId)
                .HasName("pk_cpt");

            modelBuilder.Entity<Devis>()
                .HasKey(e => e.DevisId)
                .HasName("pk_dev");

            modelBuilder.Entity<Document>()
                .HasKey(e => e.DocumentId)
                .HasName("pk_doc");

            modelBuilder.Entity<Film>()
                .HasKey(e => e.FilmId)
                .HasName("pk_flm");

            modelBuilder.Entity<FormulaireAide>()
                .HasKey(e => e.IdFormulaire)
                .HasName("pk_foa");

            modelBuilder.Entity<Genre>()
                .HasKey(e => e.GenreId)
                .HasName("pk_gen");

            modelBuilder.Entity<Image>()
                .HasKey(e => e.Id)
                .HasName("pk_img");

            modelBuilder.Entity<ImageVariante>()
                .HasKey(e => e.ImageVarianteId)
                .HasName("pk_imv");

            modelBuilder.Entity<InfosBancaires>()
                .HasKey(e => e.IdUtilisateur)
                .HasName("pk_inb");

            modelBuilder.Entity<Joueur>()
                .HasKey(e => e.IdJoueur)
                .HasName("pk_jou");

            modelBuilder.Entity<Langue>()
                .HasKey(e => e.LangueNum)
                .HasName("pk_lng");

            modelBuilder.Entity<Ligne_commande>()
                .HasKey(e => e.LigneCommandeId)
                .HasName("pk_lcd");

            modelBuilder.Entity<Livraison>()
                .HasKey(e => e.LivraisonId)
                .HasName("pk_liv");

            modelBuilder.Entity<Match>()
                .HasKey(e => e.MatchId)
                .HasName("pk_mch");

            modelBuilder.Entity<Media>()
                .HasKey(e => e.MediaId)
                .HasName("pk_med");

            modelBuilder.Entity<Monnaie>()
                .HasKey(e => e.MonnaieId)
                .HasName("pk_mon");

            modelBuilder.Entity<Pays>()
                .HasKey(e => e.NumPays)
                .HasName("pk_pay");

            modelBuilder.Entity<Poste>()
                .HasKey(e => e.NumPoste)
                .HasName("pk_pos");

            modelBuilder.Entity<Produit>()
                .HasKey(e => e.IdProduit)
                .HasName("pk_pro");

            modelBuilder.Entity<Produit_Similaire>()
                .HasKey(e => new { e.ProduitUn, e.ProduitDeux })
                .HasName("pk_pds");

            modelBuilder.Entity<Reglement>()
                .HasKey(e => e.NumTransaction)
                .HasName("pk_reg");

            modelBuilder.Entity<Remporte>()
                .HasKey(e => new { e.IdJoueur, e.NumTrophee, e.Annee })
                .HasName("pk_rem");

            modelBuilder.Entity<>()
                .HasKey(e => e.)
                .HasName("pk_");

            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
