using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_albumimage_ali")]
    public class AlbumImage
    {
        [Key]
        [Column("alb_id")]
        public int AlbumId { get; set; }

        [Key]
        [Column("img_id")]
        public int ImageId { get; set; }

        [ForeignKey(nameof(AlbumId))]
        [InverseProperty(nameof(Album.LiensImages))]
        public virtual Album AlbumNavigation { get; set; } = null!;

        [ForeignKey(nameof(ImageId))]
        [InverseProperty(nameof(Image.LiensAlbums))]
        public virtual Image ImageNavigation { get; set; } = null!;
    }
}
