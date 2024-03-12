using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_media_med")]
    public class Media
    {
        public Media()
        {
            LiensArticles = new HashSet<ArticleMedia>();
        }

        [Key]
        [Column("med_id")]
        public int IdMedia { get; set; }

        [Required]
        [Column("med_url")]
        public string Url { get; set; } = null!;

        [InverseProperty(nameof(ArticleMedia.MediaNavigation))]
        public virtual ICollection<ArticleMedia> LiensArticles { get; set; }
    }
}
