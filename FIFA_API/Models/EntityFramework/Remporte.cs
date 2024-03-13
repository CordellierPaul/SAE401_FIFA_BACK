using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_remporte_rem")]
    public partial class Remporte
    {
        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Key]
        [Column("tro_num")]
        public int NumTrophee { get; set; }

        [Key]
        [Column("rem_annee", TypeName = "char(4)")]
        public char Annee { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("RemportesJoueur")]
        public virtual Joueur JoueurRemportant { get; set; } = null!;

        [ForeignKey(nameof(NumTrophee))]
        [InverseProperty("NumTrophee")]
        public virtual Trophee Trophee { get; set; } = null!;
    }
}
