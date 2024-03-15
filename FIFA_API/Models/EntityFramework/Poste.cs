using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_poste_pos")]
    public partial class Poste
    {
        [Key]
        [Column("pos_id")]
        public int PosteId { get; set; }

        [Column("pos_libelle")]
        [StringLength(25)]
        public string PosteLibelle { get; set; }


        [InverseProperty(nameof(Joueur.PosteJoueur))]
        public virtual ICollection<Joueur> JoueursPoste { get; set; }
    }
}
