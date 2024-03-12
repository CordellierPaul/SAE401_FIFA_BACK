using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_livraison_liv")]
    public class Livraison
    {

        [Key]
        [Column("liv_id")]
        public int LivraisonId { get; set; }

        [Column("liv_type")]
        public string TypeLivraison { get; set; } = null!;

        [Column("liv_prix")]
        public double PrixLivraison { get; set; }
        

        [InverseProperty(nameof(Commande.LivraisonCommande))]
        public virtual List<Commande> CommandesLivraison { get; set; } = new List<Commande>();




    }
}
