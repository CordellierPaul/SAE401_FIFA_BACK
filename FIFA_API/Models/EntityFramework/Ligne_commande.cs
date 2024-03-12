using System.ComponentModel.DataAnnotations;
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
        public int CouleurId { get; set; }

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
        [InverseProperty("Lignes_commande")]
        public virtual Variante_Produit Produit { get; set; } = null!;

        [ForeignKey(nameof(CouleurId))]
        [InverseProperty("Lignes_commande")]
        public virtual Variante_Produit Couleur { get; set; } = null!;
        /// pas sur s'il le faut vu que idcouleur et idproduit viennent de la même table

        [ForeignKey(nameof(CommandeId))]
        [InverseProperty("Lignes_commande")]
        public virtual Commande Commande { get; set; } = null!;

        [ForeignKey(nameof(NumTaille))]
        [InverseProperty("Lignes_commande")]
        public virtual Taille Taille { get; set; } = null!;



    }
}
