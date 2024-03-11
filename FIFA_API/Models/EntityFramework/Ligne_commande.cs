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

        [Column("idproduit")]
        public int IdProduit { get; set; }

        [Column("idcouleur")]
        public int IdCouleur { get; set; }

        [Column("numtaille")]
        public int NumTaille { get; set; }

        [Column("quantite")]
        public int Quantite { get; set; }

        [Column("prixlignecommande")]
        public int PrixLigneCommande { get; set; }
    }
}
