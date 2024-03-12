using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("like_album")]
    public class Like_Album
    {

        [Key]
        [Column("idalbum")]
        public int IdAlbum { get; set; }

        [Key]
        [Column("idutilisateur")]
        public int IdUtilisateur { get; set; }


        [ForeignKey(nameof(IdAlbum))]
        [InverseProperty("Likes_album")]
        public virtual Album Album { get; set; }


        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("Likes_album")]
        public virtual Utilisateur Utilisateur { get; set; }


    }
}
