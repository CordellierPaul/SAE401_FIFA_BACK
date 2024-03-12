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

        [ForeignKey(nameof(ProduitUn))]
        [InverseProperty("IdProduit")]
        public virtual Produit PremierProduit { get; set; }

        [ForeignKey(nameof(ProduitDeux))]
        [InverseProperty("IdProduit")]
        public virtual Produit DeuxiemeProduit { get; set; }
    }
}
