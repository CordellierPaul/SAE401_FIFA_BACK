using FIFA_API.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_vote_vot")]
    public partial class Vote
    {
        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Key]
        [Column("the_id")]
        public int ThemeId { get; set; }

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [Required]
        [Column("vot_note")]
        public int VoteNote { get; set; }

        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateur.VotesUtilisateur))]
        public virtual Utilisateur? UtilisateurVotant { get; set; } = null!;

        [ForeignKey(nameof(ThemeId))]
        [InverseProperty(nameof(Theme.VotesTheme))]
        public virtual Theme? ThemeVote { get; set; } = null!;

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty(nameof(Joueur.VotesJoueur))]
        public virtual Joueur? JoueurVote { get; set; } = null!;
    }
}
