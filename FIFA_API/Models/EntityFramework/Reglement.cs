using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("reglement")]
    public partial class Reglement
    {
        [Key]
        [Column("NUMTRANSACTION")]
        public int NumTransaction { get; set; }

        [Column("NUMCOMMANDE")]
        public int NumCommande { get; set; }

        [Column("MONTANT")]
        public decimal Montant { get; set; }

        [Column("DATEREGLEMENT", TypeName = "date")]
        public DateTime DateReglement { get; set; }

        [ForeignKey(nameof(NumCommande))]
        [InverseProperty("NumCommande")]
        public virtual Commande Commande { get; set; }
    }
}
