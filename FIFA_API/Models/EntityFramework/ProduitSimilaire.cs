using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_produit_similaire_prs")]
    public partial class ProduitSimilaire
    {
        [Key]
        [Column("pro_un")]
        public int ProduitUnId { get; set; }

        [Key]
        [Column("pro_deux")]
        public int ProduitDeuxId { get; set; }

        [ForeignKey(nameof(ProduitUnId))]
        [InverseProperty(nameof(Produit.ProduitSimilaireLienUn))]
        public virtual Produit PremierProduit { get; set; } = null!;

        [ForeignKey(nameof(ProduitDeuxId))]
        [InverseProperty(nameof(Produit.ProduitSimilaireLienDeux))]
        public virtual Produit DeuxiemeProduit { get; set; } = null!;
    }
}
