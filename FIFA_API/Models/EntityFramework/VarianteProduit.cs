using FIFA_API.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_variante_produit_vpd")]
    public partial class VarianteProduit
    {
        [Key]
        [Column("vpd_id")]
        public int VarianteProuitId { get; set; }

        [Column("pro_id")]
        public int ProduitId { get; set; }

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
        [InverseProperty(nameof(Produit.VariantesProduit))]
        public virtual Produit ProduitVariante { get; set; } = null!;

        [ForeignKey(nameof(ColorisId))]
        [InverseProperty(nameof(Coloris.VariantesColorises))]
        public virtual Coloris ColorisVariante { get; set; } = null!;


        public virtual ICollection<LigneCommande> LignesCommandes { get; set; } = new HashSet<LigneCommande>();

        [InverseProperty(nameof(ImageVariante.VarianteProduitNavigation))]
        public virtual ICollection<ImageVariante> LienImages { get; set; } = new HashSet<ImageVariante>();
    }
}
