using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_articlejoueur")]
    public class ArticleJoueur
    {
        [Key]
        [Column("art_id")]
        public int IdArticle { get; set; }

        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [ForeignKey(nameof(IdArticle))]
        [InverseProperty(nameof(Article.LiensJoueur))]
        public virtual Article ArticleNavigation { get; set; } = null!;

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty(nameof(Joueur.LiensArticles))]
        public virtual Joueur JoueurNavigation { get; set; } = null!;
    }
}
