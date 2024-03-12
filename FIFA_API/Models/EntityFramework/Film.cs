using Microsoft.CodeAnalysis.Differencing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_film_flm")]
    public partial class Film
    {
        [Key]
        [Column("flm_url")]
        public string Url { get; set; }

        [ForeignKey(nameof(Url))]
        [InverseProperty("FilmHeritage")]
        public virtual Media Media { get; set; }

        public Film()
        {
            Url = null!;
        }
    }
}
