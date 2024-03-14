using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_ligne_commande_lcd")]
    public class LigneCommande
    {

        [Key]
        [Column("cmd_numcommande")]
        public int CommandeId { get; set; }

        [Key]
        [Column("lcd_id")]
        public int LigneCommandeId { get; set; }

        [Required]
        [Column("lcd_num")]
        public int NumeroLigneCommande { get; set; }

        [Required]
        [Column("vpd_id")]
        public int VarianteProduitId { get; set; }

        [Required]
        [Column("tll_numtaille")]
        public int NumTaille { get; set; }

        [Required]
        [Column("lcd_quantite")]
        public int QuantiteLigneCommande { get; set; }

        [Required]
        [Column("lcd_prix")]
        public int PrixLigneCommande { get; set; }


        [ForeignKey(nameof(VarianteProduitId))]
        [InverseProperty(nameof(VarianteProduit.LignesCommandesVariante))]
        public virtual VarianteProduit VarianteProduitNavigation { get; set; } = null!;


        [ForeignKey(nameof(CommandeId))]
        [InverseProperty("LignesCommandes")]
        public virtual Commande CommandeNavigation { get; set; } = null!;

        [ForeignKey(nameof(NumTaille))]
        [InverseProperty("LignesCommandes")]
        public virtual Taille TailleNavigation { get; set; } = null!;


    }
}
