using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_imagevariante_imv")]
    public partial class ImageVariante
    {
        [Key]
        [Column("t_e_image_variante_imv")]
        public int ImageId { get; set; }

        [Key]
        [Column("pro_id")]
        public int ProduitVariantId { get; set; }

        [Required]
        [Column("cou_id")]
        public int IdCouleur { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty("ImageVariante")]
        public virtual Image Image { get; set; } = null!;

        [ForeignKey(nameof(ProduitVariantId))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdProduit { get; set; } = null!;

        [ForeignKey(nameof(IdCouleur))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdCouleur { get; set; } = null!;
    }
}
