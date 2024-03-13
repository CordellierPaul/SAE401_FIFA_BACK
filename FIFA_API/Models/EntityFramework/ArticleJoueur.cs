using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_articlejoueur_atj")]
    public class ArticleJoueur
    {
        [Key]
        [Column("art_id")]
        public int ArticleId { get; set; }

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [ForeignKey(nameof(ArticleId))]
        [InverseProperty(nameof(Article.LiensJoueur))]
        public virtual Article ArticleNavigation { get; set; } = null!;

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty(nameof(Joueur.LiensArticles))]
        public virtual Joueur JoueurNavigation { get; set; } = null!;
    }
}
