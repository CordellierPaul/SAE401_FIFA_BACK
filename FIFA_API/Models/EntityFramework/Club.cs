using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework

{
    [Table("t_e_club_club")]
    public partial class Club
    {

        [Key]
        [Column("club_id")]
        public int ClubId { get; set; }

        [Column("club_nom")]
        [StringLength(50)]
        public string ClubNom { get; set; } = null!;

        [Column("club_initiales")]
        [StringLength(50)]
        public string ClubInitiales { get; set; } = null!;
    }
}
