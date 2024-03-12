using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_activite_acti")]
    public class Activite
    {
        [Key]
        [Column("acti_id")]
        public int Id { get; set; }

        [Column("acti_nom")]
        [StringLength(100)]
        public string Nom { get; set; } = null!;
    }
}
