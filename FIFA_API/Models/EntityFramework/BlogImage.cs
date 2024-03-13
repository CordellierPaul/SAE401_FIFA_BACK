using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_blogimage_bli")]
    public class BlogImage
    {
        [Key]
        [Column("blg_id")]
        public int BlogId { get; set; }

        [Key]
        [Column("img_id")]
        public int ImageId { get; set; }

        [ForeignKey(nameof(BlogId))]
        [InverseProperty(nameof(Blog.LiensImages))]
        public virtual Blog BlogNavigation { get; set; } = null!;

        [ForeignKey(nameof(ImageId))]
        [InverseProperty(nameof(Image.LiensBlogs))]
        public virtual Image ImageNavigation { get; set; } = null!;
    }
}
