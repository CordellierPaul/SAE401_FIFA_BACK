using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_genre_gen")]
    public partial class Genre
    {

        public Genre()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        [Column("gen_id")]
        public int GenreId { get; set; }

        [Required]
        [Column("gen_nom")]
        [StringLength(10)]
        public string GenreNom { get; set; } = null!;

        [InverseProperty("Genre")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
