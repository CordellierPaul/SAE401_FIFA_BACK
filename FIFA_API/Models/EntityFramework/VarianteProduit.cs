using FIFA_API.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_variante_produit_varpro")]
    public partial class VarianteProduit
    {
        [Key]
        [Column("pro_id")]
        public int IdProduit { get; set; }

        [Key]
        [Column("cou_id")]
        public int IdCouleur { get; set; }

        [Column("varpro_prixvariante", TypeName = "decimal")]
        [Required]
        public decimal PrixVariante { get; set; }

        [Column("varpro_promo", TypeName = "decimal")]
        [Required]
        [Range(0, 1, ErrorMessage = "La promo doit être comprise entre 0 et 1")]
        public decimal Promo { get; set; }

        [ForeignKey(nameof(IdProduit))]
        [InverseProperty("VariantesProduit")]
        public virtual Produit Produit { get; set; }

        [ForeignKey(nameof(IdCouleur))]
        [InverseProperty("VariantesProduit")]
        public virtual Couleur Couleur { get; set; }
    }
}
