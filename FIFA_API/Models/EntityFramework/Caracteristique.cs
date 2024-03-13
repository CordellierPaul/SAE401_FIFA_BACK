using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_caracteristique_car")]
    public partial class Caracteristique
    {
        [Key]
        [Column("car_id")]
        public int CaracteristiqueId { get; set; }

        [Column("car_nom")]
        [StringLength(250)]
        public string CaracteristiqueNom { get; set; } = null!;


        [InverseProperty(nameof(CaracteristiqueProduit.CaracteristiqueNavigation))]
        public virtual ICollection<CaracteristiqueProduit> LienProduits { get; set; } = new HashSet<CaracteristiqueProduit>();
    }
}
