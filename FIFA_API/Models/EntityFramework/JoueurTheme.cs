using FIFA.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA.Models.EntityFramework
{
    [Table("t_j_joueur_theme_jot")]
    public partial class JoueurTheme
    {
        [Key]
        [Column("the_num")]
        public int NumTheme { get; set; }

        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [ForeignKey(nameof(NumTheme))]
        [InverseProperty("JoueursThemes")]
        public virtual Theme Theme { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("JoueursThemes")]
        public virtual Joueur Joueur { get; set; }
    }
}
