using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_ville_vil")]
    public partial class Ville
    {

        [Key]
        [Column("vil_id")]
        public int IdVille { get; set; }

        [Column("pay_id")]
        public int NumPays { get; set; }

        [Column("vil_nom")]
        [StringLength(50)]
        public string NomVille { get; set; } = null!;

        [Column("vil_codepostal", TypeName = "char(5)")]
        public char CodePostal { get; set; }


        [ForeignKey(nameof(NumPays))]
        [InverseProperty(nameof(Pays.VillesPays))]
        public virtual Pays PaysVille{ get; set; } = null!;

        [InverseProperty(nameof(Joueur.VilleJoueur))]
        public virtual ICollection<Joueur> JoueursVille { get; set; } = new HashSet<Joueur>();

        [InverseProperty(nameof(Adresse.LienVille))]
        public virtual ICollection<Adresse> LiensAdresses { get; set; } = new HashSet<Adresse>();
    }
}
