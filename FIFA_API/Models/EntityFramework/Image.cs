using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_image_img")]
    public partial class Image
    {
        public Image()
        {
            LiensAlbums = new HashSet<AlbumImage>();
        }

        [Key]
        [Column("img_id")]
        public int Id { get; set; }

        [Column("img_url")]
        public string Url { get; set; } = null!;

        [ForeignKey(nameof(Url))]
        [InverseProperty("ImageHeritage")]
        public virtual Media Media { get; set; }

        [InverseProperty(nameof(AlbumImage.ImageNavigation))]
        public virtual ICollection<AlbumImage> LiensAlbums { get; set; }
    }
}
