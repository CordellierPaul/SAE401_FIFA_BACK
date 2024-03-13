using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_reglement_reg")]
    public partial class Reglement
    {


        [Key]
        [Column("tra_num")]
        public int NumTransaction { get; set; }

        [Column("com_num")]
        public int NumCommande { get; set; }

        [Column("reg_montant")]
        public decimal Montant { get; set; }

        [Column("reg_date", TypeName = "date")]
        public DateTime DateReglement { get; set; }

        [ForeignKey(nameof(NumCommande))]
        [InverseProperty(nameof(Commande.LignesCommandes))]
        public virtual Commande? CommandeRegle { get; set; }
    }
}
