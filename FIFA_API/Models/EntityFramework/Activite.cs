using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_activite_ati")]
    public class Activite
    {
        [Key]
        [Column("ati_id")]
        public int Id { get; set; }

        [Column("ati_nom")]
        [StringLength(100)]
        public string Nom { get; set; } = null!;
    }
}
