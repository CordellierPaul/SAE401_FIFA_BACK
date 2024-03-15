using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_match_joue_mtj")]
    public class MatchJoue
    {

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [Key]
        [Column("mch_id")]
        public int MatchId { get; set; }

        [Required]
        [Column("mtj_nbbuts")]
        [DefaultValue("0")]
        public int NbButs { get; set; }

        [Required]
        [Column("mtj_nbminutes")]
        [DefaultValue("0")]
        public int NbMinutes { get; set; }

        [Column("mtj_titularisation")]
        [StringLength(1)]
        public string Titularisation { get; set; } = null!;

        [Column("mtj_selection")]
        [StringLength(1)]
        public string Selection { get; set; } = null!;




        [ForeignKey(nameof(JoueurId))]
        [InverseProperty("Matches_joue")]
        public virtual Joueur JoueurNavigation { get; set; } = null!;


        [ForeignKey(nameof(MatchId))]
        [InverseProperty("Matches_joue")]
        public virtual Match MatchNavigation { get; set; } = null!;



    }
}
