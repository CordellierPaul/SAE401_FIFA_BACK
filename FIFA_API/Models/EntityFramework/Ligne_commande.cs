﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_ligne_commande_lcd")]
    public class Ligne_commande
    {

        [Key]
        [Column("cmd_numcommande")]
        public int CommandeId { get; set; }

        [Key]
        [Column("lcd_id")]
        public int LigneCommandeId { get; set; }

        [Required]
        [Column("pdt_id")]
        public int ProduitId { get; set; }

        [Required]
        [Column("clr_id")]
        public int ColorisId { get; set; }

        [Required]
        [Column("tll_numtaille")]
        public int NumTaille { get; set; }

        [Required]
        [Column("lcd_quantite")]
        public int QuantiteLigneCommande { get; set; }

        [Required]
        [Column("lcd_prix")]
        public int PrixLigneCommande { get; set; }


        [ForeignKey(nameof(ProduitId))]
        [InverseProperty("LignesCommandes")]
        public virtual VarianteProduit ProduitNavigation { get; set; } = null!;

        /*
        [ForeignKey(nameof(ColorisId))]
        [InverseProperty("Lignes_commande")]
        public virtual VarianteProduit ColorisNavigation { get; set; } = null!;
        */

        [ForeignKey(nameof(CommandeId))]
        [InverseProperty("LignesCommandes")]
        public virtual Commande CommandeNavigation { get; set; } = null!;

        [ForeignKey(nameof(NumTaille))]
        [InverseProperty("LignesCommandes")]
        public virtual Taille TailleNavigation { get; set; } = null!;


    }
}
