using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml.Linq;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    [Index(nameof(TelAcheteur), Name = "uq_utl_telacheteur", IsUnique = true)]
    [Index(nameof(NumTva), Name = "uq_utl_numtva", IsUnique = true)]
    [Index(nameof(NumSociete), Name = "uq_utl_numSociete", IsUnique = true)]
    [Index(nameof(IdCompte), Name = "uq_utl_idcompte", IsUnique = true)]
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
        public int? IdAdresse { get; set; }

        [Column("utl_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissance { get; set; }

        [Column("com_id")]
        public int? IdCompte { get; set; }

        [Column("mon_nummonnaie")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de monnaie doit être supérieur ou égal à 1")]
        public int NumMonnaie { get; set; } = 1;

        [Column("lan_num")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de langue doit être supérieur ou égal à 1")]
        public int NumLangue { get; set; } = 1;

        [Column("utl_paysnaissance")]
        [Required]
        public int PaysNaissance { get; set; }

        [Column("utl_paysfavori")]
        [Required]
        public int PaysFavori { get; set; }

        [Column("utl_nomacheteur")]
        [StringLength(50)]
        public string NomAcheteur { get; set; } = null!;

        [Column("utl_telacheteur")]
        [StringLength(10)]
        public string TelAcheteur { get; set; } = null!;

        [Column("act_id")]
        public int? IdActivite { get; set; }

        [Column("soc_num")]
        [StringLength(14)]
        public string NumSociete { get; set; } = null!;

        [Column("utl_numtva")]
        [StringLength(11)]
        public string NumTva { get; set; } = null!;

        #region Foreign Key

        [ForeignKey(nameof(IdAdresse))]
        [InverseProperty("Utilisateurs")]
        public virtual Adresse Adresse { get; set; } = null!;

        [ForeignKey(nameof(IdCompte))]
        [InverseProperty("Utilisateurs")]
        public virtual Compte Compte { get; set; } = null!;

        [ForeignKey(nameof(NumLangue))]
        [InverseProperty("Utilisateurs")]
        public virtual Langue Langue { get; set; } = null!;

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty("Utilisateurs")]
        public virtual Activite Activite { get; set; } = null!;

        [ForeignKey(nameof(PaysFavori))]
        [InverseProperty("UtilisateursPaysFavori")]
        public virtual Pays PaysFavoriNavigation { get; set; } = null!;

        [ForeignKey(nameof(PaysNaissance))]
        [InverseProperty("UtilisateursPaysNaissance")]
        public virtual Pays PaysNaissanceNavigation { get; set; } = null!;

        [ForeignKey(nameof(NumMonnaie))]
        [InverseProperty("Utilisateurs")]
        public virtual Monnaie Monnaie { get; set; } = null!;

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

        #endregion
    }
}
