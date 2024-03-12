using FIFA.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA.Models.EntityFramework
{
    [Table("JOUEUR_THEME")]
    public partial class JoueurTheme
    {
        [Key]
        [Column("NUMTHEME")]
        public int NumTheme { get; set; }

        [Key]
        [Column("IDJOUEUR")]
        public int IdJoueur { get; set; }

        [ForeignKey(nameof(NumTheme))]
        [InverseProperty("JoueursThemes")]
        public virtual Theme Theme { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("JoueursThemes")]
        public virtual Joueur Joueur { get; set; }
    }
}
