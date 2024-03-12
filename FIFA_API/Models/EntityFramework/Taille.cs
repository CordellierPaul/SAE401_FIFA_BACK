using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("taille")]
    public partial class Taille
    {
        [Key]
        [Column("NUMTAILLE")]
        public int NumTaille { get; set; }

        [Column("LIBELLETAILLE")]
        [StringLength(25)]
        public string LibelleTaille { get; set; }

    }
}
