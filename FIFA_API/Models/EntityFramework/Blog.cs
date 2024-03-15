using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_blog_blg")]
    public class Blog
    {
        [Key]
        [Column("blg_id")]
        public int Id { get; set; }

        //[Key] ?
        [Column("art_id")]
        public int IdArticle { get; set; }  // TODO lien article

        [Column("blg_dateheure")]
        public DateTime DateHeure { get; set; }

        [Column("blg_titre")]
        public string Titre { get; set; } = null!;

        [Column("blg_resume")]
        public string Resume { get; set; } = null!;

        [Column("blg_descriptionblog")]
        public string DescriptionBlog { get; set; } = null!;


        [InverseProperty(nameof(Commentaire.BlogCommente))]
        public virtual ICollection<Commentaire> CommentairesBlog { get; set; } = new HashSet<Commentaire>();

        [InverseProperty(nameof(LikeBlog.BlogNavigation))]
        public virtual ICollection<LikeBlog> LikesBlogs { get; set; } = new HashSet<LikeBlog>();

        [InverseProperty(nameof(BlogImage.BlogNavigation))]
        public virtual ICollection<BlogImage> LiensImages { get; set; } = new HashSet<BlogImage>();


        [ForeignKey(nameof(IdArticle))]
        [InverseProperty(nameof(Article.BlogsArticle))]
        public virtual Article ArticleNavigation { get; set; } = null!;
    }
}
