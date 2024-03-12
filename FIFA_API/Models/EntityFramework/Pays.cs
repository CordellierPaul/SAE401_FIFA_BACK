using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("pays")]
    public partial class Pays
    {
        [Key]
        [Column("numpays")]
        public int NumPays { get; set; }

        [Column("nompays")]
        [StringLength(50)]
        public string NomPays { get; set; }

    }
}
