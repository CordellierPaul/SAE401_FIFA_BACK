using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_match_joue_mtj")]
    public class Match_joue
    {

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [Key]
        [Column("mch_id")]
        public int MatchId { get; set; }

        [Column("mtj_nbbuts")]
        public int NbButs { get; set; }

        [Column("mtj_nbminutes")]
        public int NbMinutes { get; set; }

        [Column("mtj_titularisation")]
        public string Titularisation { get; set; } = null!;

        [Column("mtj_selection")]
        public string Selection { get; set; } = null!;




        [ForeignKey(nameof(JoueurId))]
        [InverseProperty("Matches_joue")]
        public virtual Joueur Joueur { get; set; } = null!;


        [ForeignKey(nameof(MatchId))]
        [InverseProperty("Matches_joue")]
        public virtual Match Match { get; set; } = null!;



    }
}
