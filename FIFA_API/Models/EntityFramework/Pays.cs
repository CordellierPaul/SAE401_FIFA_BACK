using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_pays_pay")]
    public partial class Pays
    {
        [Key]
        [Column("pay_num")]
        public int NumPays { get; set; }

        [Column("pay_nom")]
        [StringLength(50)]
        public string NomPays { get; set; }


    }
}
