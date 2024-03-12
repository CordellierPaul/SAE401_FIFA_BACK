using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("trophee")]
    public partial class Trophee
    {
        [Key]
        [Column("NUMTROPHEE")]
        public int NumTrophee { get; set; }

        [Column("NOMTROPHEE")]
        [StringLength(100)]
        public string NomTrophee { get; set; }

    }
}
