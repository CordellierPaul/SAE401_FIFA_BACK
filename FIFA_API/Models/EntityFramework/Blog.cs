using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_blog_blg")]
    public class Blog
    {
        [Key]
        [Column("blg_id")]
        public int BlogId { get; set; }

        [Column("art_id")]
        public int ArticleId { get; set; }

        [Column("blg_dateheure")]
        public DateTime BlogDateHeure { get; set; }

        [Column("blg_titre")]
        public string BlogTitre { get; set; } = null!;

        [Column("blg_resume")]
        public string BlogResume { get; set; } = null!;

        [Column("blg_description")]
        public string BlogDescription { get; set; } = null!;


        [InverseProperty(nameof(Commentaire.BlogCommente))]
        public virtual ICollection<Commentaire> CommentairesBlog { get; set; } = new HashSet<Commentaire>();

        [InverseProperty(nameof(LikeBlog.BlogNavigation))]
        public virtual ICollection<LikeBlog> LikesBlogs { get; set; } = new HashSet<LikeBlog>();

        [InverseProperty(nameof(BlogImage.BlogNavigation))]
        public virtual ICollection<BlogImage> LiensImages { get; set; } = new HashSet<BlogImage>();


        [ForeignKey(nameof(ArticleId))]
        [InverseProperty(nameof(Article.BlogsArticle))]
        public virtual Article ArticleNavigation { get; set; } = null!;
    }
}
