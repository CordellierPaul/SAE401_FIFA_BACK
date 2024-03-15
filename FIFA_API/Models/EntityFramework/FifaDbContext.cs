using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace FIFA_API.Models.EntityFramework
{
    public partial class FifaDbContext : DbContext
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        public FifaDbContext() { }

        public FifaDbContext(DbContextOptions<FifaDbContext> options)
            : base(options)
        { }

        #region Propriétés des entités de la base de données

        public virtual DbSet<Action> Action { get; set; } = null!;
        public virtual DbSet<Activite> Activite { get; set; } = null!;
        public virtual DbSet<Adresse> Adresse { get; set; } = null!;
        public virtual DbSet<Album> Album { get; set; } = null!;
        public virtual DbSet<Anecdote> Anecdote { get; set; } = null!;
        public virtual DbSet<Article> Article { get; set; } = null!;
        public virtual DbSet<Blog> Blog { get; set; } = null!;
        public virtual DbSet<Caracteristique> Caracteristique { get; set; } = null!;
        public virtual DbSet<Categorie> Categorie { get; set; } = null!;
        public virtual DbSet<Club> Club { get; set; } = null!;
        public virtual DbSet<Coloris> Coloris { get; set; } = null!;
        public virtual DbSet<Commande> Commande { get; set; } = null!;
        public virtual DbSet<Commentaire> Commentaire { get; set; } = null!;
        public virtual DbSet<Competition> Competition { get; set; } = null!;
        public virtual DbSet<Compte> Compte { get; set; } = null!;
        public virtual DbSet<Devis> Devis { get; set; } = null!;
        public virtual DbSet<Document> Document { get; set; } = null!;
        public virtual DbSet<Film> Film { get; set; } = null!;
        public virtual DbSet<FormulaireAide> FormulaireAide { get; set; } = null!;
        public virtual DbSet<Genre> Genre { get; set; } = null!;
        public virtual DbSet<Image> Image { get; set; } = null!;
        public virtual DbSet<InfosBancaires> InfosBancaires { get; set; } = null!;
        public virtual DbSet<Joueur> Joueur { get; set; } = null!;
        public virtual DbSet<Langue> Langue { get; set; } = null!;
        public virtual DbSet<LigneCommande> LigneCommande { get; set; } = null!;
        public virtual DbSet<Livraison> Livraison { get; set; } = null!;
        public virtual DbSet<Match> Match { get; set; } = null!;
        public virtual DbSet<Media> Media { get; set; } = null!;
        public virtual DbSet<Monnaie> Monnaie { get; set; } = null!;
        public virtual DbSet<Pays> Pays { get; set; } = null!;
        public virtual DbSet<Poste> Poste { get; set; } = null!;
        public virtual DbSet<Produit> Produit { get; set; } = null!;
        public virtual DbSet<Reglement> Reglement { get; set; } = null!;
        public virtual DbSet<Taille> Taille { get; set; } = null!;
        public virtual DbSet<Theme> Theme { get; set; } = null!;
        public virtual DbSet<Trophee> Trophee { get; set; } = null!;
        public virtual DbSet<Utilisateur> Utilisateur { get; set; } = null!;
        public virtual DbSet<VarianteProduit> VarianteProduit { get; set; } = null!;
        public virtual DbSet<Ville> Ville { get; set; } = null!;
        public virtual DbSet<Vote> Vote { get; set; } = null!;

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Il faudra donner des infos sur la base ici
            modelBuilder.Entity<Reglement>(entity =>
            {
                entity.Property(e => e.DateReglement).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.DateHeure).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Compte>(entity =>
            {
                entity.Property(e => e.CompteDateConnexion).HasDefaultValueSql("now()");
            });
            modelBuilder.Entity<Compte>().HasIndex(u => u.CompteEmail).IsUnique();

            #region Null

            #endregion

            #region foreignkey

            //ForeignKey Devis
            modelBuilder.Entity<Devis>()
                .HasOne(p => p.UtilisateurDevis)
                .WithMany(d => d.LiensDevis)
                .HasForeignKey(p => p.UtilisateurId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dev_utl");

            modelBuilder.Entity<Devis>()
                .HasOne(p => p.ProduitDevis)
                .WithMany(d => d.DevisProduit)
                .HasForeignKey(p => p.ProduitId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_dev_pro");


            //ForeignKey Film
            modelBuilder.Entity<Film>()
                .HasOne(p => p.FilmMedia)
                .WithMany(d => d.MediaFilm)
                .HasForeignKey(p => p.MediaId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_flm_med");


            //ForeignKey FormulaireAide
            modelBuilder.Entity<FormulaireAide>()
                .HasOne(p => p.UtilisateurDuFormulaire)
                .WithMany(d => d.FormulairesAideUtilisateur)
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_foa_utl");

            modelBuilder.Entity<FormulaireAide>()
               .HasOne(p => p.FormulaireAction)
               .WithMany(d => d.ActionFormulaireAide)
               .HasForeignKey(p => p.IdAction)
               .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_foa_act");

            //ForeignKey Image
            modelBuilder.Entity<Image>()
                .HasOne(p => p.MediaImage)
                .WithMany(m => m.ImagesMedia)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey InfosBancaires
            modelBuilder.Entity<InfosBancaires>()
                .HasOne(p => p.UtilisateurInfoBc)
                .WithMany(d => d.InfosBancairesUtilisateur)
                .HasForeignKey(p => p.IdUtilisateur)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("fk_inb_utl");

            //ForeignKey Joueur
            modelBuilder.Entity<Joueur>(entity =>
            {
                entity.HasOne(j => j.VilleJoueur)
                    .WithMany(v => v.JoueursVille)
                    .HasForeignKey(p => p.IdVille)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(j => j.ClubJoueur)
                    .WithMany()
                    .HasForeignKey(p => p.IdClub)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(j => j.PosteJoueur)
                    .WithMany(d => d.JoueursPoste)
                    .HasForeignKey(p => p.NumPoste)
                    .OnDelete(DeleteBehavior.Restrict);

                //Lien Anecdote/joueur
                entity.HasMany(j => j.LienAnecdotes)
                    .WithOne(a => a.JoueurNavigation)
                    .HasForeignKey(a => a.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_anc_jou");
            });

            //ForeignKey Ligne_commande
            modelBuilder.Entity<LigneCommande>(entity =>
            {
                entity.HasKey(e => new { e.CommandeId, e.LigneCommandeId })
                    .HasName("pk_lcd");

                entity.HasOne(d => d.VarianteProduitNavigation)
                    .WithMany(p => p.LignesCommandesVariante)
                    .HasForeignKey(d => d.VarianteProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lcd_vpd");

                entity.HasOne(d => d.CommandeNavigation)
                    .WithMany(p => p.LignesCommandes)
                    .HasForeignKey(d => d.CommandeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lcd_cmd");

                entity.HasOne(d => d.TailleNavigation)
                    .WithMany(p => p.LignesCommandes)
                    .HasForeignKey(d => d.TailleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lcd_tai");
            });

            //ForeignKey Like_Album
            modelBuilder.Entity<LikeAlbum>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.UtilisateurId })
                    .HasName("pk_lab");

                entity.HasOne(d => d.AlbumNavigation)
                    .WithMany(p => p.LikesAlbums)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lab_alb");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.LikesAlbums)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lab_utl");

            });


            //ForeignKey Like_Article
            modelBuilder.Entity<LikeArticle>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.UtilisateurId })
                    .HasName("pk_lar");

                entity.HasOne(d => d.ArticleNavigation)
                    .WithMany(p => p.LikesArticles)
                    .HasForeignKey(d => d.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lar_art");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.LikesArticles)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lar_utl");

            });


            //ForeignKey Like_Blog
            modelBuilder.Entity<LikeBlog>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.UtilisateurId })
                    .HasName("pk_lbg");

                entity.HasOne(d => d.BlogNavigation)
                    .WithMany(p => p.LikesBlogs)
                    .HasForeignKey(d => d.BlogId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lbg_blg");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.LikesBlogs)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_lbg_utl");

            });


            //ForeignKey Like_Document
            modelBuilder.Entity<LikeDocument>(entity =>
            {
                entity.HasKey(e => new { e.DocumentId, e.UtilisateurId })
                    .HasName("pk_ldc");

                entity.HasOne(d => d.DocumentNavigation)
                    .WithMany(p => p.LikesDocuments)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ldc_doc");

                entity.HasOne(d => d.UtilisateurNavigation)
                    .WithMany(p => p.LikesDocuments)
                    .HasForeignKey(d => d.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ldc_utl");

            });

            //ForeignKey Match
            modelBuilder.Entity<Match>(entity =>
            {

                entity.HasOne(d => d.ClubDomicileMatch)
                    .WithMany(p => p.MatchesDomicile)
                    .HasForeignKey(d => d.ClubDomicileId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mchdom_clb");

                entity.HasOne(d => d.ClubExterieurMatch)
                    .WithMany(p => p.MatchesExterieur)
                    .HasForeignKey(d => d.ClubExterieurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mchext_clb");

            });

            //ForeignKey Match_joue
            modelBuilder.Entity<MatchJoue>(entity =>
            {
                entity.HasKey(e => new { e.JoueurId, e.MatchId })
                    .HasName("pk_mtj");

                entity.HasOne(d => d.JoueurNavigation)
                    .WithMany(p => p.Matches_joue)
                    .HasForeignKey(d => d.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mtj_jou");

                entity.HasOne(d => d.MatchNavigation)
                    .WithMany(p => p.Matches_joue)
                    .HasForeignKey(d => d.MatchId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_mtj_mch");
            });

            //ForeignKey Produit
            modelBuilder.Entity<Produit>(entity =>
            {
                entity.HasOne(p => p.PaysProduit)
                    .WithMany(p => p.ProduitsPays)
                    .HasForeignKey(p => p.PaysId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_pay");

                entity.HasOne(p => p.CategorieNavigation)
                    .WithMany(p => p.ProduitsCategorie)
                    .HasForeignKey(p => p.CategorieId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_cat");

                entity.HasOne(p => p.CompetitionProduit)
                    .WithMany(p => p.ProduitsCompetition)
                    .HasForeignKey(p => p.IdCompetition)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_cpn");

                entity.HasOne(p => p.GenreProduit)
                    .WithMany(p => p.ProduitsGenre)
                    .HasForeignKey(p => p.GenreId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pro_gen");
            });

            //ForeignKey ProduitSimilaire
            modelBuilder.Entity<ProduitSimilaire>(entity =>
            {
                entity.HasKey(p => new { p.ProduitUnId, p.ProduitDeuxId })
                    .HasName("pk_prs");

                entity.HasOne(p => p.PremierProduit)
                    .WithMany(p => p.ProduitSimilaireLienUn)
                    .HasForeignKey(p => p.ProduitUnId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prs_pro_un");

                entity.HasOne(p => p.DeuxiemeProduit)
                    .WithMany(p => p.ProduitSimilaireLienDeux)
                    .HasForeignKey(p => p.ProduitDeuxId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_prs_pro_deux");
            });

            //ForeignKey Reglement
            modelBuilder.Entity<Reglement>()
                .HasOne(p => p.CommandeRegle)
                .WithMany(p => p.ReglementsCommande)
                .HasForeignKey(p => p.CommandeId)
                .OnDelete(DeleteBehavior.Restrict);

            //ForeignKey Remporte
            modelBuilder.Entity<Remporte>()
                .HasOne(p => p.JoueurRemportant)
                .WithMany(p => p.RemportesJoueur)
                .HasForeignKey(p => p.JoueurId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Remporte>()
                .HasOne(p => p.TropheeRemporte)
                .WithMany(t => t.RemportesTrophee)
                .HasForeignKey(p => p.TropheeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Remporte>()
                .HasKey(e => new { e.JoueurId, e.TropheeId, e.Annee })
                    .HasName("pk_rem");


            //ForeignKey SousCategorie
            modelBuilder.Entity<SousCategorie>(entity =>
            {
                entity.HasKey(e => new { e.CategorieParentId, e.CategorieEnfantId })
                    .HasName("pk_sct");

                entity.HasOne(e => e.ObjCategorieEnfant)
                    .WithMany(e => e.EnfantsCategorie)
                    .HasForeignKey(e => e.CategorieEnfantId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.ObjCategorieParent)
                    .WithMany(e => e.ParentsCategorie)
                    .HasForeignKey(e => e.CategorieParentId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //ForeignKey Stock
            modelBuilder.Entity<Stock>(entity =>
            {
                entity.HasKey(e => e.StockId)
                    .HasName("pk_stk");

                entity.HasOne(e => e.TailleStockee)
                    .WithMany(t => t.StocksTaille)
                    .HasForeignKey(e => e.TailleId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.VarianteStockee)
                    .WithMany(e => e.StocksVariante)
                    .HasForeignKey(e => e.VarianteProduitId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //ForeignKey Utilisateur
            modelBuilder.Entity<Utilisateur>(entity =>
            {
                entity.HasOne(p => p.AdresseUtilisateur)
                    .WithMany(a => a.UtilisateursAdresse)
                    .HasForeignKey(p => p.AdresseId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Relation one to one entre utilisateur et compte (un compte n'a
                // pas obligatoirement d'utilisateur donc IsRequired est à false) :
                entity.HasOne(e => e.CompteUtilisateur)
                    .WithOne(e => e.UtilisateurCompte)
                    .HasForeignKey<Utilisateur>(e => e.CompteId)
                    .IsRequired(false);

                entity.HasOne(p => p.LangueUtilisateur)
                    .WithMany()
                    .HasForeignKey(p => p.LangueId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.MonnaieUtilisateur)
                    .WithMany()
                    .HasForeignKey(p => p.NumMonnaie)
                    .OnDelete(DeleteBehavior.Restrict);

                // Pays de naissance de l'utilisateur
                entity.HasOne(e => e.PaysNaissanceNavigation)
                    .WithMany(e => e.UtilisateursNesPays)
                    .HasForeignKey(e => e.PaysNaissanceId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pay_utl_pays_nassance")
                    .IsRequired();

                // Pays favori de l'utilisateur
                entity.HasOne(e => e.PaysFavoriNavigation)
                    .WithMany(e => e.UtilisateursFavorisantPays)
                    .HasForeignKey(e => e.PaysFavoriId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_pay_utl_pays_favori")
                    .IsRequired();
            });

            //ForeignKey VarianteProduit
            modelBuilder.Entity<VarianteProduit>(entity =>
            {
                entity.HasKey(e => e.VarianteProduitId)
                    .HasName("pk_vpd");

                entity.HasOne(p => p.ProduitVariante)
                    .WithMany()
                    .HasForeignKey(p => p.ProduitId)
                    .HasConstraintName("fk_vpd_pro")
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(p => p.ColorisVariante)
                    .WithMany(c => c.VariantesColorises)
                    .HasForeignKey(p => p.ColorisId)
                    .HasConstraintName("fk_vpd_clr")
                    .OnDelete(DeleteBehavior.Restrict);
            });

            //ForeignKey Vote
            modelBuilder.Entity<Vote>(entity =>
            {
                // Les Primary keys sont définies à la fin de ce fichier

                entity.HasOne(p => p.UtilisateurVotant)
                    .WithMany(u => u.VotesUtilisateur)
                    .HasForeignKey(p => p.UtilisateurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_vot_utl");

                entity.HasOne(p => p.ThemeVote)
                    .WithMany(t => t.VotesTheme)
                    .HasForeignKey(p => p.ThemeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_vot_the");

                entity.HasOne(p => p.JoueurVote)
                    .WithMany(j => j.VotesJoueur)
                    .HasForeignKey(p => p.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_vot_jou");
            });


            //ForeignKey Ville
            modelBuilder.Entity<Ville>(entity =>
            {
                entity.HasOne(p => p.PaysVille)
                    .WithMany()
                    .HasForeignKey(p => p.PaysId)
                    .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(v => v.LiensAdresses)
                    .WithOne(a => a.LienVille)
                    .HasForeignKey(a => a.VilleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_vil_adr");
            });

            //ForeignKey AlbumImages
            modelBuilder.Entity<AlbumImage>(entity =>
            {
                entity.HasKey(e => new { e.AlbumId, e.ImageId })
                    .HasName("pk_ali");

                entity.HasOne(e => e.AlbumNavigation)
                    .WithMany(a => a.LiensImages)
                    .HasForeignKey(e => e.AlbumId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ali_alb");

                entity.HasOne(e => e.ImageNavigation)
                    .WithMany(i => i.LiensAlbums)
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_ali_img");
            });

            //ForeignKey ArticleJoueur
            modelBuilder.Entity<ArticleJoueur>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.JoueurId })
                    .HasName("pk_atj");

                entity.HasOne(e => e.ArticleNavigation)
                    .WithMany(a => a.LiensJoueur)
                    .HasForeignKey(e => e.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_atj_art");

                entity.HasOne(e => e.JoueurNavigation)
                    .WithMany(j => j.LiensArticles)
                    .HasForeignKey(e => e.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_atj_jou");
            });

            //ForeignKey ArticleMedia
            modelBuilder.Entity<ArticleMedia>(entity =>
            {
                entity.HasKey(e => new { e.ArticleId, e.MediaId })
                    .HasName("pk_atm");

                entity.HasOne(e => e.ArticleNavigation)
                    .WithMany(a => a.LiensMedias)
                    .HasForeignKey(e => e.ArticleId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_atm_art");

                entity.HasOne(e => e.MediaNavigation)
                    .WithMany(a => a.LiensArticles)
                    .HasForeignKey(e => e.MediaId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_atm_med");
            });

            //ForeignKey Blog
            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasOne(e => e.ArticleNavigation)
                    .WithMany(a => a.BlogsArticle)
                    .HasForeignKey(e => e.IdArticle)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_blg_art");
            });

            //ForeignKey BlogImage
            modelBuilder.Entity<BlogImage>(entity =>
            {
                entity.HasKey(e => new { e.BlogId, e.ImageId })
                    .HasName("pk_bli");

                entity.HasOne(e => e.BlogNavigation)
                    .WithMany(b => b.LiensImages)
                    .HasForeignKey(e => e.BlogId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_bli_blg");

                entity.HasOne(e => e.ImageNavigation)
                    .WithMany(i => i.LiensBlogs)
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_bli_img");
            });

            //ForeignKey CaracteristiqueProduit
            modelBuilder.Entity<CaracteristiqueProduit>(entity =>
            {
                entity.HasKey(e => new { e.CaracteristiqueId, e.ProduitId })
                    .HasName("pk_cpd");

                entity.HasOne(e => e.CaracteristiqueNavigation)
                    .WithMany(i => i.LienProduits)
                    .HasForeignKey(e => e.CaracteristiqueId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cpd_car");

                entity.HasOne(e => e.ProduitNavigation)
                    .WithMany(j => j.LienCaracteristiques)
                    .HasForeignKey(e => e.ProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_cpd_pro");
            });

            //ForeignKey ImageJoueur
            modelBuilder.Entity<ImageJoueur>(entity =>
            {
                entity.HasKey(e => new { e.ImageId, e.JoueurId })
                    .HasName("pk_imj");

                entity.HasOne(e => e.ImageNavigation)
                    .WithMany(i => i.LiensJoueurs)
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_imj_img");

                entity.HasOne(e => e.JoueurNavigation)
                    .WithMany(j => j.LiensImages)
                    .HasForeignKey(e => e.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_imj_jou");
            });

            //ForeignKey ImageVariante
            modelBuilder.Entity<ImageVariante>(entity =>
            {
                entity.HasKey(e => new { e.ImageId, e.VarianteProduitId })
                    .HasName("pk_imv");

                entity.HasOne(e => e.VarianteProduitNavigation)
                    .WithMany(v => v.LienImages)
                    .HasForeignKey(e => e.VarianteProduitId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_imv_vpd");

                entity.HasOne(e => e.ImageNavigation)
                    .WithMany()
                    .HasForeignKey(e => e.ImageId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_imv_img");
            });

            //ForeignKey JoueurTheme
            modelBuilder.Entity<JoueurTheme>(entity =>
            {
                entity.HasKey(e => new { e.ThemeId, e.JoueurId })
                      .HasName("pk_jot");

                entity.HasOne(p => p.ThemeNavigation)
                    .WithMany(t => t.LienJoueur)
                    .HasForeignKey(p => p.ThemeId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_jot_the");

                entity.HasOne(p => p.JoueurNavigation)
                    .WithMany(j => j.LienTheme)
                    .HasForeignKey(p => p.JoueurId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_jot_jou");
            });

            //Avait été fait plus haut
            /*
            //ForeignKey Remporte
            modelBuilder.Entity<Remporte>(entity =>
            {
                entity.HasKey(e => new { e.IdJoueur, e.NumTrophee, e.Annee })
                    .HasName("pk_rem");

                entity.HasOne(d => d.JoueurRemportant)
                    .WithMany(p => p.RemportesJoueur)
                    .HasForeignKey(d => d.IdJoueur)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("fk_rem_jou");

                //TO DO
            });*/

            #endregion

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

            modelBuilder.Entity<Categorie>()
                .HasKey(e => e.CategorieId)
                .HasName("pk_cat");

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

            modelBuilder.Entity<InfosBancaires>()
                .HasKey(e => e.IdUtilisateur)
                .HasName("pk_inb");

            modelBuilder.Entity<Joueur>()
                .HasKey(e => e.IdJoueur) 
                .HasName("pk_jou");

            modelBuilder.Entity<Langue>()
                .HasKey(e => e.LangueId)
                .HasName("pk_lng");

            modelBuilder.Entity<LigneCommande>()
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
                .HasKey(e => e.PaysId)
                .HasName("pk_pay");

            modelBuilder.Entity<Poste>()
                .HasKey(e => e.PosteId)
                .HasName("pk_pos");

            modelBuilder.Entity<Produit>()
                .HasKey(e => e.IdProduit)
                .HasName("pk_pro");

            modelBuilder.Entity<Reglement>()
                .HasKey(e => e.TransactionId) 
                .HasName("pk_reg");

            modelBuilder.Entity<Taille>()
                .HasKey(e => e.NumTaille)
                .HasName("pk_tai");

            modelBuilder.Entity<Theme>()
                .HasKey(e => e.ThemeId)
                .HasName("pk_the");

            modelBuilder.Entity<Trophee>()
                .HasKey(e => e.TropheeId)
                .HasName("pk_tro");

            modelBuilder.Entity<Utilisateur>() 
                .HasKey(e => e.UtilisateurId)
                .HasName("pk_utl");

            modelBuilder.Entity<VarianteProduit>()
                .HasKey(e => e.VarianteProduitId)
                .HasName("pk_vpd");

            modelBuilder.Entity<Ville>()
                .HasKey(e => e.VilleId)
                .HasName("pk_vil");

            modelBuilder.Entity<Vote>()
                .HasKey(e => new { e.UtilisateurId, e.ThemeId, e.JoueurId })
                .HasName("pk_vot");

            #endregion

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
