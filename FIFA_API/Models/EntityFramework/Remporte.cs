using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_remporte_rem")]
    public partial class Remporte
    {
        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [Key]
        [Column("tro_id")]
        public int TropheeId { get; set; }

        [Key]
        [Column("rem_annee", TypeName = "char(4)")]
        public char RemporteAnnee { get; set; }

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty("RemportesJoueur")]
        public virtual Joueur JoueurRemportant { get; set; } = null!;

        [ForeignKey(nameof(TropheeId))]
        [InverseProperty(nameof(Trophee.RemportesTrophee))]
        public virtual Trophee TropheeRemporte { get; set; } = null!;
    }
}
