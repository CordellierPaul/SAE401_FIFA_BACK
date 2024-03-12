using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_trophee_tro")]
    public partial class Trophee
    {
        [Key]
        [Column("tro_num")]
        public int NumTrophee { get; set; }

        [Column("tro_nom")]
        [StringLength(100)]
        public string NomTrophee { get; set; }

    }
}
