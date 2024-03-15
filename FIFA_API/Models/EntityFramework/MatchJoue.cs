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
        public int MatchJoueNbButs { get; set; }

        [Required]
        [Column("mtj_nbminutes")]
        [DefaultValue("0")]
        public int MatchJoueNbMinutes { get; set; }

        [Column("mtj_titularisation")]
        [StringLength(1)]
        public string MatchJoueTitularisation { get; set; } = null!;

        [Column("mtj_selection")]
        [StringLength(1)]
        public string MatchJoueSelection { get; set; } = null!;




        [ForeignKey(nameof(JoueurId))]
        [InverseProperty("Matches_joue")]
        public virtual Joueur JoueurNavigation { get; set; } = null!;


        [ForeignKey(nameof(MatchId))]
        [InverseProperty("Matches_joue")]
        public virtual Match MatchNavigation { get; set; } = null!;



    }
}
