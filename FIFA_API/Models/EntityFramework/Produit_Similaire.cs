using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("PRODUIT_SIMILAIRE")]
    public partial class Produit_Similaire
    {
        [Key]
        [Column("PRODUITUN")]
        public int ProduitUn { get; set; }

        [Key]
        [Column("PRODUITDEUX")]
        public int ProduitDeux { get; set; }
    }
}
