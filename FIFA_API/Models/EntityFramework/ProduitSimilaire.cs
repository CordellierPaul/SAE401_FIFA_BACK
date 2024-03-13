using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_produit_similaire_prs")]
    public partial class ProduitSimilaire
    {
        //[Key]     // J'ai essayé un truc et ça n'a pas marché :(
        //[Column("pro_id_un")]
        //public int ProduitSimilaireId { get; set; }

        [Key]
        [Column("pro_id_un")]
        public int ProduitUnId { get; set; }

        [Key]
        [Column("pro_id_deux")]
        public int ProduitDeuxId { get; set; }

        [ForeignKey(nameof(ProduitUnId))]
        [InverseProperty(nameof(Produit.ProduitSimilaireLienUn))]
        public virtual Produit PremierProduit { get; set; } = null!;

        [ForeignKey(nameof(ProduitDeuxId))]
        [InverseProperty(nameof(Produit.ProduitSimilaireLienDeux))]
        public virtual Produit DeuxiemeProduit { get; set; } = null!;
    }
}
