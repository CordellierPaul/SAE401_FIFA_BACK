using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("ligne_commande")]
    public class Ligne_commande
    {

        [Key]
        [Column("numcommande")]
        public int NumCommande { get; set; }

        [Key]
        [Column("numlignecommande")]
        public int NumLigneCommande { get; set; }

        [Required]
        [Column("idproduit")]
        public int IdProduit { get; set; }

        [Required]
        [Column("idcouleur")]
        public int IdCouleur { get; set; }

        [Required]
        [Column("numtaille")]
        public int NumTaille { get; set; }

        [Required]
        [Column("quantite")]
        public int Quantite { get; set; }

        [Required]
        [Column("prixlignecommande")]
        public int PrixLigneCommande { get; set; }

        [ForeignKey(nameof(IdProduit))]
        [InverseProperty("Lignes_commande")]
        public virtual Variante_Produit Produit { get; set; }

        //[ForeignKey(nameof(IdCouleur))]
        //[InverseProperty("Lignes_commande")]
        //public virtual Variante_Produit Couleur { get; set; }
        /// pas sur s'il le faut vu que idcouleur et idproduit viennent de la même table

        [ForeignKey(nameof(NumCommande))]
        [InverseProperty("Lignes_commande")]
        public virtual Commande Commande { get; set; }

        [ForeignKey(nameof(NumTaille))]
        [InverseProperty("Lignes_commande")]
        public virtual Taille Taille { get; set; }



    }
}
