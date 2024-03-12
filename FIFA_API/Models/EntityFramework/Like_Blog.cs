using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("like_blog")]
    public class Like_Blog
    {

        [Key]
        [Column("idblog")]
        public int IdBlog { get; set; }

        [Key]
        [Column("idutilisateur")]
        public int IdUtilisateur { get; set; }



        [ForeignKey(nameof(IdBlog))]
        [InverseProperty("Likes_blog")]
        public virtual Blog Blog { get; set; }


        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("Likes_blog")]
        public virtual Utilisateur Utilisateur { get; set; }

    }
}
