using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("DEVIS")]
    public partial class Devis
    {
        [Key]
        [Column("IDDEVIS")]
        public int DevisId { get; set; }

        [Required]
        [Column("IDUTILISATEUR")]
        public int UtilisateurId { get; set; }

        [Column("IDPRODUIT")]
        public int? ProduitId { get; set; }

        [Required]
        [Column("SUJET")]
        [StringLength(100)]
        public string Sujet { get; set; } = null!;

        [Required]
        [Column("MESSAGE")]
        [StringLength(1000)]
        public string Message { get; set; } = null!;

        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("Devis")]
        public virtual Utilisateur Utilisateur { get; set; }

        [ForeignKey(nameof(ProduitId))]
        [InverseProperty("Devis")]
        public virtual Produit Produit { get; set; }
    }
}

