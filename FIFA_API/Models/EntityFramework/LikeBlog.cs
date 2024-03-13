using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_blog_lbg")]
    public class LikeBlog
    {

        [Key]
        [Column("blg_id")]
        public int BlogId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }



        [ForeignKey(nameof(BlogId))]
        [InverseProperty(nameof(Blog.LikesBlogs))]
        public virtual Blog BlogNavigation { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("Likes_blog")]
        public virtual Utilisateur UtilisateurNavigation { get; set; } = null!;

    }
}
