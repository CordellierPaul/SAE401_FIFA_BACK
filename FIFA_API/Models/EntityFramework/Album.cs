using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_album_alb")]
    public class Album
    {
        public Album()
        {
            LiensImages = new HashSet<AlbumImage>();
        }

        [Key]
        [Column("alb_id")]
        public int Id { get; set; }

        [Column("alb_date_heure")]
        public DateTime DateHeure { get; set; }

        [Column("alb_titre")]
        [StringLength(50)]
        public string Titre { get; set; } = null!;

        [Column("alb_resume")]
        [StringLength(250)]
        public string Resume { get; set; } = null!;

        [InverseProperty(nameof(AlbumImage.AlbumNavigation))]
        public virtual ICollection<AlbumImage> LiensImages { get; set; }

        [InverseProperty("AlbumCommente")]
        public virtual List<Commentaire> CommentairesAlbum { get; set; } = new List<Commentaire>();


        [InverseProperty(nameof(Like_Album.AlbumNavigation))]
        public virtual ICollection<Like_Album> LikesAlbums { get; set; }
    }
}
