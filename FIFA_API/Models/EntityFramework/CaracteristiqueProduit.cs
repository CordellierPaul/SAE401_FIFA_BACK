using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_caracteristique_produit_cpd")]
    public partial class CaracteristiqueProduit
    {
        [Key]
        [Column("car_id")]
        public int CaracteristiqueId { get; set; }

        [Key]
        [Column("pro_id")]
        public int ProduitId { get; set; }

        [ForeignKey(nameof(CaracteristiqueId))]
        [InverseProperty(nameof(Caracteristique.LienProduits))]
        public virtual Caracteristique CaracteristiqueNavigation { get; set; } = null!;

        [ForeignKey(nameof(ProduitId))]
        [InverseProperty(nameof(Produit.LienCaracteristiques))]
        public virtual Produit ProduitNavigation { get; set; } = null!;
    }
}
