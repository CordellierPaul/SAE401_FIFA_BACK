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

        [Column("user_id")]
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
    }
}
