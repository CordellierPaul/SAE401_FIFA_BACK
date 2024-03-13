using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework

{
    [Table("t_e_club_clb")]
    public partial class Club
    {

        [Key]
        [Column("clb_id")]
        public int ClubId { get; set; }

        [Column("clb_nom")]
        [StringLength(50)]
        public string ClubNom { get; set; } = null!;

        [Column("clb_initiales")]
        [StringLength(50)]
        public string ClubInitiales { get; set; } = null!;




        [InverseProperty(nameof(Match.ClubDomicile))]
        public virtual ICollection<Match> MatchesDomicile { get; set; } = new HashSet<Match>();


        [InverseProperty(nameof(Match.ClubExterieur))]
        public virtual ICollection<Match> MatchesExterieur { get; set; } = new HashSet<Match>();


        [InverseProperty(nameof(Joueur.ClubJoueur))]
        public virtual ICollection<Joueur> JoueursClub { get; set; } = new HashSet<Joueur>();

    }
}
