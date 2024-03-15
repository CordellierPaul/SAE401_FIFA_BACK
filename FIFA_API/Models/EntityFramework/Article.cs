using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_article_art")]
    public class Article
    {
        public Article()
        {
            LiensJoueur = new HashSet<ArticleJoueur>();
            LiensMedias = new HashSet<ArticleMedia>();
        }

        [Key]
        [Column("art_id")]
        public int Id { get; set; }

        [Column("art_dateheure")]
        public DateTime DateHeure { get; set; }

        [Column("art_titre")]
        public string Titre { get; set; } = null!;

        [Column("art_resume")]
        public string Resume { get; set; } = null!;

        [Column("art_texte")]
        public string Texte { get; set; } = null!;


        [InverseProperty(nameof(ArticleJoueur.ArticleNavigation))]
        public virtual ICollection<ArticleJoueur> LiensJoueur { get; set; }

        [InverseProperty(nameof(ArticleMedia.ArticleNavigation))]
        public virtual ICollection<ArticleMedia> LiensMedias { get; set; }

        [InverseProperty(nameof(LikeArticle.ArticleNavigation))]
        public virtual ICollection<LikeArticle> LikesArticles { get; set; }

        [InverseProperty(nameof(Commentaire.ArticleCommente))] 
        public virtual ICollection<Commentaire> CommentairesArticle { get; set; } = new HashSet<Commentaire>();

        [InverseProperty(nameof(Blog.ArticleNavigation))]
        public virtual ICollection<Blog> BlogsArticle { get; set; } = new HashSet<Blog>();
    }
}
