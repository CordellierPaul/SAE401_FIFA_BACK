using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_trophee_tro")]
    public partial class Trophee
    {


        [Key]
        [Column("tro_id")]
        public int TropheeId { get; set; }

        [Column("tro_nom")]
        [StringLength(100)]
        public string NomTrophee { get; set; }


        [InverseProperty(nameof(Remporte.TropheeRemporte))]
        public virtual ICollection<Remporte> RemportesTrophee { get; set; } = new HashSet<Remporte>();


    }
}
