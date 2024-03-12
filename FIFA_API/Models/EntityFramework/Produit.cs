using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("produit")]
    public partial class Produit
    {
        [Key]
        [Column("idproduit")]
        public int IdProduit { get; set; }

        [Column("numgenre")]
        public int NumGenre { get; set; }

        [Column("numcategorie")]
        public int NumCategorie { get; set; }

        [Column("NOMPRODUIT")]
        [StringLength(100)]
        public string NomProduit { get; set; }

        [Column("DESCRIPTIONPRODUIT")]
        [StringLength(1000)]
        public string? DescriptionProduit { get; set; }

        [Column("IDCOMPETITION")]
        public int? IdCompetition { get; set; }

        [Column("NUMPAYS")]
        public int? NumPays { get; set; }
    }
}
