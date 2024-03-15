using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_reglement_reg")]
    public partial class Reglement
    {


        [Key]
        [Column("tra_id")]
        public int TransactionId { get; set; }

        [Column("com_id")]
        public int CommandeId { get; set; }

        [Column("reg_montant")]
        public decimal Montant { get; set; }

        [Column("reg_date", TypeName = "date")]
        public DateTime DateReglement { get; set; }


        [ForeignKey(nameof(CommandeId))]
        [InverseProperty(nameof(Commande.ReglementsCommande))]
        public virtual Commande CommandeRegle { get; set; }
    }
}
