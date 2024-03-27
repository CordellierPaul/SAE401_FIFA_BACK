using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    [Microsoft.EntityFrameworkCore.Index(nameof(UtilisateurTelAcheteur), Name = "uq_utl_telacheteur", IsUnique = true)]
    [Microsoft.EntityFrameworkCore.Index(nameof(UtilisateurNumTva), Name = "uq_utl_numtva", IsUnique = true)]
    [Microsoft.EntityFrameworkCore.Index(nameof(SocieteId), Name = "uq_utl_numSociete", IsUnique = true)]
    [Microsoft.EntityFrameworkCore.Index(nameof(CompteId), Name = "uq_utl_idcompte", IsUnique = true)]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Required]
        [Column("utl_prenom")]
        [StringLength(50)]
        public string PrenomUtilisateur { get; set; } = null!;

        [Column("adr_id")]
        public int? AdresseId { get; set; }

        [Column("utl_datenaissance", TypeName = "date")]
        [Required]
        public DateTime UtilisateurDateNaissance { get; set; }

        [Column("com_id")]
        public int? CompteId { get; set; }

        [Column("mon_id")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de monnaie doit être supérieur ou égal à 1")]
        public int MonnaieId { get; set; } = 1;

        [Column("lan_id")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de langue doit être supérieur ou égal à 1")]
        public int LangueId { get; set; } = 1;

        [Column("pay_paysnaissance_id")]
        public int PaysNaissanceId { get; set; }

        [Column("pay_paysfavori_id")]
        public int? PaysFavoriId { get; set; }

        [Column("utl_nomacheteur")]
        [StringLength(50)]
        public string? UtilisateurNomAcheteur { get; set; }

        [Column("utl_telacheteur")]
        [StringLength(10)]
        public string? UtilisateurTelAcheteur { get; set; }

        [Column("act_id")]
        public int? ActiviteId { get; set; }

        [Column("soc_id")]
        [StringLength(14)]
        public string? SocieteId { get; set; }

        [Column("utl_numtva")]
        [StringLength(11)]
        public string? UtilisateurNumTva { get; set; }

        #region Foreign Key

        [ForeignKey(nameof(AdresseId))]
        [InverseProperty(nameof(Adresse.UtilisateursAdresse))]
        public virtual Adresse? AdresseUtilisateur { get; set; }

        [ForeignKey(nameof(CompteId))]
        [InverseProperty(nameof(Compte.UtilisateurCompte))]
        public virtual Compte? CompteUtilisateur { get; set; }

        [ForeignKey(nameof(LangueId))]
        [InverseProperty(nameof(Langue.UtilisateursLangue))]
        public virtual Langue? LangueUtilisateur { get; set; }

        [ForeignKey(nameof(ActiviteId))]
        [InverseProperty(nameof(Activite.UtilisateursActivite))]
        public virtual Activite? ActiviteUtilisateur { get; set; }

        [ForeignKey(nameof(PaysFavoriId))]
        [InverseProperty(nameof(Pays.UtilisateursFavorisantPays))]
        public virtual Pays? PaysFavoriNavigation { get; set; } = null!;

        [ForeignKey(nameof(PaysNaissanceId))]
        [InverseProperty(nameof(Pays.UtilisateursNesPays))]
        public virtual Pays? PaysNaissanceNavigation { get; set; }

        [ForeignKey(nameof(MonnaieId))]
        [InverseProperty(nameof(Monnaie.UtilisateursMonnaie))]
        public virtual Monnaie? MonnaieUtilisateur { get; set; }

        #endregion

        #region InverseProperty

        [InverseProperty("UtilisateurCommentant")] 
        public virtual ICollection<Commentaire> CommentairesUtilisateur { get; set; } = new List<Commentaire>();
        
        [InverseProperty(nameof(Commande.UtilisateurCommandant))]
        public virtual ICollection<Commande> CommandesUtilisateur { get; set; } = new List<Commande>();


        [InverseProperty(nameof(LikeAlbum.UtilisateurNavigation))]
        public virtual ICollection<LikeAlbum> LikesAlbums { get; set; } = new List<LikeAlbum>();


        [InverseProperty(nameof(LikeArticle.UtilisateurNavigation))]
        public virtual ICollection<LikeArticle> LikesArticles { get; set; } = new List<LikeArticle>();


        [InverseProperty(nameof(LikeBlog.UtilisateurNavigation))]
        public virtual ICollection<LikeBlog> LikesBlogs { get; set; } = new HashSet<LikeBlog>();


        [InverseProperty(nameof(LikeDocument.UtilisateurNavigation))]
        public virtual ICollection<LikeDocument> LikesDocuments { get; set; } = new HashSet<LikeDocument>();

        [InverseProperty(nameof(Devis.UtilisateurDevis))]
        public virtual ICollection<Devis> LiensDevis { get; set; } = new HashSet<Devis>();

        [InverseProperty(nameof(FormulaireAide.UtilisateurDuFormulaire))]
        public virtual ICollection<FormulaireAide> FormulairesAideUtilisateur { get; set; } = new HashSet<FormulaireAide>();

        [InverseProperty(nameof(InfosBancaires.UtilisateurInfoBc))]
        public virtual ICollection<InfosBancaires> InfosBancairesUtilisateur { get; set; } = new HashSet<InfosBancaires>();

        [InverseProperty(nameof(Vote.UtilisateurVotant))]
        public virtual ICollection<Vote> VotesUtilisateur { get; set; } = new HashSet<Vote>();

        #endregion
    }
}
