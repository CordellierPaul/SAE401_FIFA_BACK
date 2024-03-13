using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_joueur_theme_jot")]
    public partial class JoueurTheme
    {
        [Key]
        [Column("the_num")]
        public int ThemeId { get; set; }

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [ForeignKey(nameof(ThemeId))]
        [InverseProperty(nameof(Theme.LienJoueur))]
        public virtual Theme ThemeNavigation { get; set; } = null!;

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty(nameof(Joueur.LienTheme))]
        public virtual Joueur JoueurNavigation { get; set; } = null!;
    }
}
