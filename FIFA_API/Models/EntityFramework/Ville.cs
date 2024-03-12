using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("ville")]
    public partial class Ville
    {
        [Key]
        [Column("IDVILLE")]
        public int IdVille { get; set; }

        [Column("NUMPAYS")]
        public int NumPays { get; set; }

        [Column("NOMVILLE")]
        [StringLength(50)]
        public string NomVille { get; set; }

        [Column("CODEPOSTAL", TypeName = "char(5)")]
        public char CodePostal { get; set; }


        [ForeignKey(nameof(NumPays))]
        [InverseProperty("NumPays")]
        public virtual Pays Pays{ get; set; }

    }
}
