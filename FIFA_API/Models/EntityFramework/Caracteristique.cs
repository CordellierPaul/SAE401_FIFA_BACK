using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_caracteristique_caract")]
    public partial class Caracteristique
    {
        [Key]
        [Column("caract_id")]
        public int CaracteristiqueId { get; set; }

        [Column("caract_nom")]
        [StringLength(250)]
        public string CaracteristiqueNom { get; set; } = null!;


        [InverseProperty("CaracteristiqueProduit")]
        public virtual ICollection<Caracteristique_produit> ProduitsCaracteristique { get; set; } = new List<Caracteristique_produit>();
    }
}
