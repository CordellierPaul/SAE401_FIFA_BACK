using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using FIFA.Models.EntityFramework;

namespace FIFA_API.Models.EntityFramework
{
    [Table("remporte")]
    public partial class Remporte
    {
        [Key]
        [Column("idjoueur")]
        public int IdJoueur { get; set; }

        [Key]
        [Column("NUMTROPHEE")]
        public int NumTrophee { get; set; }

        [Key]
        [Column("ANNEE", TypeName = "char(4)")]
        public char Annee { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("IdJoueur")]
        public virtual Joueur Joueur { get; set; }

        [ForeignKey(nameof(NumTrophee))]
        [InverseProperty("NumTrophee")]
        public virtual Trophee Trophee { get; set; }
    }
}
