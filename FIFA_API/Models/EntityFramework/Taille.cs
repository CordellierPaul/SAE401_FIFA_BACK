using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_taille_tai")]
    public partial class Taille
    {
        [Key]
        [Column("tai_num")]
        public int NumTaille { get; set; }

        [Column("tai_libelle")]
        [StringLength(25)]
        public string LibelleTaille { get; set; }






        [InverseProperty(nameof(Ligne_commande.TailleNavigation))]
        public virtual ICollection<Ligne_commande> LignesCommandes { get; set; }
    }
}
