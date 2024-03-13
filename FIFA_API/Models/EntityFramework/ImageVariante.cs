﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_imagevariante_imv")]
    [Index(nameof(Url), Name = "uq_url_lienpdf", IsUnique = true)]
    [Index(nameof(IdCouleur), Name = "uq_idcouleur_lienpdf", IsUnique = true)]
    [Index(nameof(IdProduit), Name = "uq_idproduit_lienpdf", IsUnique = true)]
    public partial class ImageVariante
    {
        [Key]
        [Column("t_e_image_variante_imv")]
        public int ImageVarianteId { get; set; }

        [Required]
        [Column("imv_url")]
        public string Url { get; set; } = null!;

        [Required]
        [Column("pro_id")]
        public int IdProduit { get; set; }

        [Required]
        [Column("cou_id")]
        public int IdCouleur { get; set; }

        [ForeignKey(nameof(Url))]
        [InverseProperty("ImageVariante")]
        public virtual Image Image { get; set; } = null!;

        [ForeignKey(nameof(IdProduit))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdProduit { get; set; } = null!;

        [ForeignKey(nameof(IdCouleur))]
        [InverseProperty("ImageVariantes")]
        public virtual VarianteProduit VarianteProduitIdCouleur { get; set; } = null!;
    }
}