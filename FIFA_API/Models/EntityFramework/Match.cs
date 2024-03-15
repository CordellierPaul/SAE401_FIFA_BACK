using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_match_mch")]
    public class Match
    {

        [Key]
        [Column("mch_id")]
        public int MatchId { get; set; }


        [Column("clb_domicileid")]
        public int ClubDomicileId { get; set; }

        [Column("clb_exterieurid")]
        public int ClubExterieurId { get; set; }

        [Column("mch_datematch", TypeName = "date")]
        public DateTime DateMatch { get; set; }

        [Column("mch_scoredomicile")]
        public int ScoreDomicile { get; set; }

        [Column("mch_ScoreExterieur")]
        public int ScoreExterieur { get; set; }





        [ForeignKey(nameof(ClubDomicileId))]
        [InverseProperty(nameof(Club.MatchesDomicile))]
        public virtual Club ClubDomicileMatch { get; set; }


        [ForeignKey(nameof(ClubExterieurId))]
        [InverseProperty(nameof(Club.MatchesExterieur))]
        public virtual Club ClubExterieurMatch { get; set; }



        [InverseProperty(nameof(MatchJoue.MatchNavigation))]
        public virtual ICollection<MatchJoue> Matches_joue { get; set; } = new HashSet<MatchJoue>();


    }
}
