using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_imagevariante_imv")]
    public partial class ImageVariante
    {
        [Key]
        [Column("vpd_id")]
        public int VarianteProduitId { get; set; }

        [Key]
        [Column("img_id")]
        public int ImageId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty(nameof(VarianteProduit.LienImages))]
        public virtual VarianteProduit VarianteProduitNavigation { get; set; } = null!;

        [ForeignKey(nameof(ImageId))]
        //[InverseProperty(nameof(Image.LiensVarianteProduits))]  // ?
        public virtual Image ImageNavigation { get; set; } = null!;
    }
}
