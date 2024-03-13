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
        public int IdUtilisateur { get; set; }

        [Key]
        [Column("the_num")]
        public int NumTheme { get; set; }

        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Required]
        [Column("vot_note")]
        public int Note { get; set; }

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty(nameof(Utilisateur.VotesUtilisateur))]
        public virtual Utilisateur UtilisateurVotant { get; set; } = null!;

        [ForeignKey(nameof(NumTheme))]
        [InverseProperty(nameof(Theme.VotesTheme))]
        public virtual Theme ThemeVote { get; set; } = null!;

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty(nameof(Joueur.VotesJoueur))]
        public virtual Joueur JoueurVote { get; set; } = null!;
    }
}
