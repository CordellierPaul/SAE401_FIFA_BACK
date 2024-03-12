using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("poste")]
    public partial class Poste
    {
        [Key]
        [Column("numposte")]
        public int NumPoste { get; set; }

        [Column("LIBELLEPOSTE")]
        [StringLength(25)]
        public string LibellePoste { get; set; }
    }
}
