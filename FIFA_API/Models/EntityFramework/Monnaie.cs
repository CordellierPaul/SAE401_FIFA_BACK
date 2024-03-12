using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_monnaie_mon")]
    public class Monnaie
    {

        [Key]
        [Required]
        [Column("mon_id")]
        public string MonnaieId { get; set; }

        [Required]
        [Column("mon_nom")]
        public string MonnaieNom { get; set; }


        [Required]
        [Column("mon_symbole")]
        public string MonnaiSymbole { get; set; }
    }
}
