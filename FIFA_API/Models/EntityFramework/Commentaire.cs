using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_commentaire_com")]
    public partial class Commentaire
    {
        [Key]
        [Column("com_id")]
        public int CommentaireId { get; set; }

        [Column("com_dateheure")]
        public DateTime CommentaireDateHeure { get; set; } = DateTime.Now;

        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("com_texte")]
        [StringLength(1000)]
        public string CommentaireTexte { get; set; } = null!;

        [Column("com_id")]
        public int CommentaireIdCommentaire { get; set; }

        [Column("doc_id")]
        public int DocumentId { get; set; }

        [Column("alb_id")]
        public int AlbumId { get; set; }

        [Column("blg_id")]
        public int BlogId { get; set; }

        [Column("art_id")]
        public int ArticleId { get; set; }


        [ForeignKey("UtilisateurId")]
        [InverseProperty("CommentairesUtilisateur")]
        public virtual Utilisateur UtilisateurCommentant { get; set; } = null!;

        [ForeignKey("CommentaireIdCommentaire")]
        [InverseProperty("CommenteCommentaire")]
        public virtual Commentaire CommentaireCommente { get; set; }

        [ForeignKey("DocumentId")]
        [InverseProperty("CommentairesDocument")]
        public virtual Document DocumentCommente { get; set; } = null!;

        [ForeignKey("AlbumId")]
        [InverseProperty("")]
        public virtual Album AlbumCommente { get; set; } = null!;

        [ForeignKey("BlogId")]
        [InverseProperty("")]
        public virtual Blog BlogCommente { get; set; } = null!;

        [ForeignKey("ArticleId")]
        [InverseProperty("")]
        public virtual Article ArticleCommente { get; set; } = null!;


        [InverseProperty("CommentaireCommente")]
        public virtual Commentaire CommenteCommentaire { get; set; }
    }
}
