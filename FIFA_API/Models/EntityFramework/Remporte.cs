using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

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
    }
}
