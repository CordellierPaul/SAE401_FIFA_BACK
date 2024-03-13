using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_pays_pay")]
    public partial class Pays
    {
        [Key]
        [Column("pay_num")]
        public int NumPays { get; set; }

        [Column("pay_nom")]
        [StringLength(50)]
        public string NomPays { get; set; }

        [InverseProperty(nameof(Produit.PaysProduit))]
        public virtual ICollection<Produit> ProduitsPays { get; set; } = new HashSet<Produit>();

        [InverseProperty(nameof(Utilisateur.PaysFavoriNavigation))]
        public virtual ICollection<Utilisateur> UtilisateursFavorisantPays { get; set; } = new HashSet<Utilisateur>();

        [InverseProperty(nameof(Utilisateur.PaysNaissanceNavigation))]
        public virtual ICollection<Utilisateur> UtilisateursNeePays { get; set; } = new HashSet<Utilisateur>();
    }
}
