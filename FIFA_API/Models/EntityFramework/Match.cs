﻿using System.ComponentModel;
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

        [Required]
        [Column("clb_domicileid")]
        public int ClubDomicileId { get; set; }

        [Required]
        [Column("clb_exterieurid")]
        public int ClubExterieurId { get; set; }

        [Required]
        [DefaultValue("current_date")]
        [Column("mch_datematch", TypeName = "date")]
        public DateTime MatchDate{ get; set; }

        [Required]
        [DefaultValue("0")]
        [Column("mch_score_domicile")]
        public int MatchScoreDomicile { get; set; }

        [Required]
        [DefaultValue("0")]
        [Column("mch_score_exterieur")]
        public int MatchScoreExterieur { get; set; }





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
