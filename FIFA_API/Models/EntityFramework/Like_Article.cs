using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("like_article")]
    public class Like_Article
    {

        [Key]
        [Column("idarticle")]
        public int IdArticle { get; set; }

        [Key]
        [Column("idutilisateur")]
        public int IdUtilisateur { get; set; }



        [ForeignKey(nameof(IdArticle))]
        [InverseProperty("Likes_article")]
        public virtual Article Article { get; set; }


        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("Likes_article")]
        public virtual Utilisateur Utilisateur { get; set; }

    }
}
