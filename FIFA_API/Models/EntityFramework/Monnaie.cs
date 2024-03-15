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
        public int MonnaieId { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("mon_nom")]
        public string MonnaieNom { get; set; } = null!;

        [Required]
        [StringLength(1)]
        [Column("mon_symbole")]
        public string MonnaieSymbole { get; set; } = null!;


        [InverseProperty(nameof(Utilisateur.MonnaieUtilisateur))]
        public virtual ICollection<Utilisateur> UtilisateursMonnaie { get; set; } = new HashSet<Utilisateur>();
    }
}
