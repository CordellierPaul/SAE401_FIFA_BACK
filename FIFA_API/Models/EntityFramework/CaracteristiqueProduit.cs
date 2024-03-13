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



        [ForeignKey("CaracteristiqueId")]
        [InverseProperty("ProduitsCaracteristique")]
        public virtual Caracteristique CaracteristiqueCaracterisant { get; set; } = null!;

    }
}
