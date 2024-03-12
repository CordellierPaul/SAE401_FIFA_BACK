using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_commande_cmd")]
    public partial class Commande
    {
        [Key]
        [Column("cmd_id")]
        public int CommandeId { get; set; }

        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("adr_id")]
        public int AdresseId { get; set; }

        [Column("liv_id")]
        public int LivraisonId { get; set; }

        [Column("cmd_prix")]
        public decimal CommandePrix { get; set; }

        [Column("cmd_datecommande")]
        public DateTime CommandeDateCommande { get; set; }

        [Column("cmd_etatcommande")]
        [StringLength(25)]
        public string CommandeEtatCommande { get; set; } = null!;

        [Column("cmd_domicile")]
        public Boolean CommandeDomicil { get; set; }

        [Column("cmd_datelivraison")]
        public DateTime CommandeDateLivraison { get; set; }

    }
}
