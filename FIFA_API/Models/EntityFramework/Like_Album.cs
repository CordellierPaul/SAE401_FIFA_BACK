using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_album_lab")]
    public class Like_Album
    {

        [Key]
        [Column("alb_id")]
        public int AlbumId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }


        [ForeignKey(nameof(AlbumId))]
        [InverseProperty("LikesAlbums")]
        public virtual Album AlbumNavigation { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("LikesAlbums")]
        public virtual Utilisateur UtilisateurNavigation { get; set; } = null!;


    }
}
