using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_produit_similaire_prs")]
    public partial class ProduitSimilaire
    {
        [Key]
        [Column("pro_un")]
        public int ProduitUn { get; set; }

        [Key]
        [Column("pro_deux")]
        public int ProduitDeux { get; set; }

        [ForeignKey(nameof(ProduitUn))]
        [InverseProperty("ProduitSimilaire")]
        public virtual Produit PremierProduit { get; set; } = null!;

        [ForeignKey(nameof(ProduitDeux))]
        [InverseProperty("ProduitSimilaire")]
        public virtual Produit DeuxiemeProduit { get; set; } = null!;
    }
}
