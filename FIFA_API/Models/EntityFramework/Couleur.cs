using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_coloris_clr")]
    public partial class Coloris
    {
        [Key]
        [Column("clr_id")]
        public int ColorisId { get; set; }

        [Column("clr_nom")]
        [StringLength(1000)]
        public string ColorisNom { get; set; } = null!;
    }
}
