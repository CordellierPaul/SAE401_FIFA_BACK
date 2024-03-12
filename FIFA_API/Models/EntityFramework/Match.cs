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

        [Column("mch_datematch")]
        public DateTime DateMatch { get; set; }

        [Column("mch_scoredomicile")]
        public int ScoreDomicile { get; set; }

        [Column("mch_ScoreExterieur")]
        public int ScoreExterieur { get; set; }





        [ForeignKey(nameof(ClubDomicileId))]
        [InverseProperty("Matches")]
        public virtual Club ClubDomicile { get; set; }


        [ForeignKey(nameof(ClubExterieurId))]
        [InverseProperty("Matches")]
        public virtual Club ClubExterieur { get; set; }



    }
}
