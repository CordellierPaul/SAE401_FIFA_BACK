using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_articlemedia")]
    public class ArticleMedia
    {
        [Key]
        [Column("art_id")]
        public int IdArticle { get; set; }

        [Key]
        [Column("med_id")]
        public int IdMedia { get; set; }

        [ForeignKey(nameof(IdArticle))]
        [InverseProperty(nameof(Article.LiensMedias))]
        public virtual Article ArticleNavigation { get; set; } = null!;

        [ForeignKey(nameof(IdMedia))]
        [InverseProperty(nameof(Media.LiensArticles))]
        public virtual Media MediaNavigation { get; set; } = null!;
    }
}
