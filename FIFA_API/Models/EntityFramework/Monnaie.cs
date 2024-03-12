using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("monnaie")]
    public class Monnaie
    {

        [Key]
        [Required]
        [Column("nummonnaie")]
        public string NumMonnaie { get; set; }

        [Required]
        [Column("nommonnaie")]
        public string NomMonnaie { get; set; }


        [Required]
        [Column("symbolemonnaie")]
        public string SymboleMonnaie { get; set; }
    }
}
