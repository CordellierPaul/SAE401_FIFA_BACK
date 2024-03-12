using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_albumimage_albimg")]
    public class AlbumImage
    {
        [Key]
        [Column("alb_id")]
        public int IdAlbum { get; set; }

        [Key]
        [Column("img_id")]
        public int IdImage { get; set; }

        [ForeignKey(nameof(Album))]
        [InverseProperty("Avis")]
        public virtual Album AlbumNavigation { get; set; } = null!;

        [ForeignKey(nameof(Image))]
        [InverseProperty("Avis")]
        public virtual Image ImageNavigation { get; set; } = null!;
    }
}
