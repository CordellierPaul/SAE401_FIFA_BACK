using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_genre_gen")]
    public partial class Genre
    {

        public Genre()
        {
            ProduitsGenre = new HashSet<Produit>();
        }

        [Key]
        [Column("gen_id")]
        public int GenreId { get; set; }

        [Required]
        [Column("gen_nom")]
        [StringLength(10)]
        public string GenreNom { get; set; } = null!;

        [InverseProperty(nameof(Produit.GenreProduit))]
        public virtual ICollection<Produit> ProduitsGenre { get; set; }
    }
}
