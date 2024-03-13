using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_competition_cpn")]
    public partial class Competition
    {

        public Competition()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        [Column("cpn_id")]
        public int CompetitionId { get; set; }

        [Column("cpn_nom")]
        [StringLength(1000)]
        public string CompetitionNom { get; set; } = null!;

        [InverseProperty("Competition")]
        public virtual ICollection<Produit> Produits { get; set; }
    }
}
