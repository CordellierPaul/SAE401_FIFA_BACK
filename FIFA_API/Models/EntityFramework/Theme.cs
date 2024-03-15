using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_theme_the")]
    public partial class Theme
    {
        [Key]
        [Column("the_id")]
        public int ThemeId { get; set; }

        [Column("the_libelle")]
        [StringLength(50)]
        public string ThemeLibelle { get; set; } = null!;

        [InverseProperty(nameof(Vote.ThemeVote))]
        public virtual ICollection<Vote> VotesTheme { get; set; } = new HashSet<Vote>();

        [InverseProperty(nameof(JoueurTheme.ThemeNavigation))]
        public virtual ICollection<JoueurTheme> LienJoueur { get; set; } = new HashSet<JoueurTheme>();
    }
}
