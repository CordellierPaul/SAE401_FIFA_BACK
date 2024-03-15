using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_devis_dev")]
    public partial class Devis
    {
        [Key]
        [Column("dev_id")]
        public int DevisId { get; set; }

        [Required]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("pro_id")]
        public int ProduitId { get; set; }

        [Required]
        [Column("dev_sujet")]
        [StringLength(100)]
        public string Sujet { get; set; } = null!;

        [Required]
        [Column("dev_message")]
        [StringLength(1000)]
        public string Message { get; set; } = null!;

        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateur.LiensDevis))]
        public virtual Utilisateur UtilisateurDevis { get; set; } = null!;

        [ForeignKey(nameof(ProduitId))]
        [InverseProperty(nameof(Produit.DevisProduit))]
        public virtual Produit ProduitDevis { get; set; } = null!;
    }
}

