using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_competition_comp")]
    public partial class Competition
    {
        [Key]
        [Column("comp_id")]
        public int CompetitionId { get; set; }

        [Column("comp_nom")]
        [StringLength(1000)]
        public string CompetitionNom { get; set; } = null!;
    }
}
