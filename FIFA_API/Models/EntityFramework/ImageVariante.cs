using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FIFA.Models.EntityFramework
{
    [Table("IMAGE_VARIANTE")]
    [Index(nameof(Url), Name = "uq_url_lienpdf", IsUnique = true)]
    [Index(nameof(IdCouleur), Name = "uq_idcouleur_lienpdf", IsUnique = true)]
    [Index(nameof(IdProduit), Name = "uq_idproduit_lienpdf", IsUnique = true)]
    public partial class ImageVariante
    {
        [Key]
        [Column("IDIMGPROD")]
        public int IdImageProduit { get; set; }

        [Required]
        [Column("URL")]
        public string Url { get; set; }

        [Required]
        [Column("IDPRODUIT")]
        public int IdProduit { get; set; }

        [Required]
        [Column("IDCOULEUR")]
        public int IdCouleur { get; set; }

        [ForeignKey(nameof(Url))]
        [InverseProperty("ImageVariante")]
        public virtual Image Image { get; set; }

        [ForeignKey(nameof(IdProduit))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdProduit { get; set; }

        [ForeignKey( nameof(IdCouleur))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdCouleur { get; set; }
    }
}
