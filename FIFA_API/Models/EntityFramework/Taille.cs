using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_taille_tai")]
    public partial class Taille
    {
        [Key]
        [Column("tai_id")]
        public int NumTaille { get; set; }

        [Column("tai_libelle")]
        [StringLength(25)]
        public string LibelleTaille { get; set; }




        [InverseProperty(nameof(LigneCommande.TailleNavigation))]
        public virtual ICollection<LigneCommande> LignesCommandes { get; set; } = new HashSet<LigneCommande>();

        [InverseProperty(nameof(Stock.TailleStockee))]
        public virtual ICollection<Stock> StocksTaille { get; set; } = new HashSet<Stock>();
    }
}
