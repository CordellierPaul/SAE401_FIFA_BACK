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
        [Column("mon_nom")]
        public string Nom { get; set; } = null!;

        [Required]
        [Column("mon_symbole")]
        public string Symbole { get; set; } = null!;


        [InverseProperty(nameof(Utilisateur.MonnaieUtilisateur))]
        public virtual ICollection<Utilisateur> UtilisateursMonnaie { get; set; } = new HashSet<Utilisateur>();
    }
}
