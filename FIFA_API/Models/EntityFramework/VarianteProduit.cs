using FIFA_API.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_variante_produit_vpd")]
    public partial class VarianteProduit
    {
        [Key]
        [Column("pro_id")]
        public int ProduitId { get; set; }

        [Key]
        [Column("clr_id")]
        public int ColorisId { get; set; }

        [Column("vpd_prixvariante", TypeName = "decimal")]
        [Required]
        public decimal PrixVariante { get; set; }

        [Column("vpd_promo", TypeName = "decimal")]
        [Required]
        [Range(0, 1, ErrorMessage = "La promo doit être comprise entre 0 et 1")]
        public decimal Promo { get; set; }

        [ForeignKey(nameof(ProduitId))]
        [InverseProperty("VariantesProduit")]
        public virtual Produit Produit { get; set; } = null!;

        [ForeignKey(nameof(ColorisId))]
        [InverseProperty("VariantesProduit")]
        public virtual Coloris Coloris { get; set; }





        [InverseProperty(nameof(Ligne_commande.ProduitNavigation))]
        public virtual ICollection<Ligne_commande> LignesCommandes { get; set; }



    }
}
