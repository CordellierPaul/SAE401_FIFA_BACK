using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_article_lar")]
    public class Like_Article
    {

        [Key]
        [Column("art_id")]
        public int ArticleId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }



        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("Likes_article")]
        public virtual Article Article { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("Likes_article")]
        public virtual Utilisateur Utilisateur { get; set; } = null!;

    }
}
