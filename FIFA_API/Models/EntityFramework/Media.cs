using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_media_med")]
    public class Media
    {
        [Key]
        [Column("med_id")]
        public int MediaId { get; set; }

        [Required]
        [Column("med_url")]
        public string MediaUrl { get; set; } = null!;

        [InverseProperty(nameof(ArticleMedia.MediaNavigation))]
        public virtual ICollection<ArticleMedia> LiensArticles { get; set; } = new HashSet<ArticleMedia>();

        [InverseProperty(nameof(Film.FilmMedia))]
        public virtual ICollection<Film> MediaFilm{ get; set; } = new HashSet<Film>();

        [InverseProperty(nameof(Image.MediaImage))]
        public virtual ICollection<Image> ImagesMedia { get; set; } = new HashSet<Image>();
    }
}
