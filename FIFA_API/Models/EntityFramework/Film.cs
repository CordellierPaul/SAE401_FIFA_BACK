using Microsoft.CodeAnalysis.Differencing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {
        [Key]
        [Column("flm_id")]
        public int FilmId { get; set; }

        [Column("med_id")]
        public int MediaId { get; set; } 

        [ForeignKey(nameof(MediaId))]
        [InverseProperty(nameof(Media.MediaFilm))]
        public virtual Media FilmMedia { get; set; } = null!;
    }
}
