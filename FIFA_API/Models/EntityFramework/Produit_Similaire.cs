using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_produit_similaire_prs")]
    public partial class Produit_Similaire
    {
        [Key]
        [Column("pro_un")]
        public int ProduitUn { get; set; }

        [Key]
        [Column("pro_deux")]
        public int ProduitDeux { get; set; }

        [ForeignKey(nameof(ProduitUn))]
        [InverseProperty("IdProduit")]
        public virtual Produit PremierProduit { get; set; } = null!;

        [ForeignKey(nameof(ProduitDeux))]
        [InverseProperty("IdProduit")]
        public virtual Produit DeuxiemeProduit { get; set; } = null!;
    }
}
