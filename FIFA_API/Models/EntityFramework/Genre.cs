using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_genre_gen")]
    public partial class Genre
    {
        [Key]
        [Column("gen_num")]
        public int NumGenre { get; set; }

        [Required]
        [Column("gen_nom")]
        [StringLength(10)]
        public string GenreNom { get; set; }
    }
}
