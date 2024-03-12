using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("like_document")]
    public class Like_Document
    {

        [Key]
        [Column("iddocument")]
        public int IdDocument { get; set; }

        [Key]
        [Column("idutilisateur")]
        public int IdUtilisateur { get; set; }



        [ForeignKey(nameof(IdDocument))]
        [InverseProperty("Likes_blog")]
        public virtual Document Document { get; set; }


        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("Likes_blog")]
        public virtual Utilisateur Utilisateur { get; set; }

    }
}
