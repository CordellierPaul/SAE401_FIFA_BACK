using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_produit_pro")]
    public partial class Produit
    {
        [Key]
        [Column("pro_id")]
        public int IdProduit { get; set; }

        [Column("gen_id")]
        public int GenreId { get; set; }

        [Column("cat_num")]
        public int NumCategorie { get; set; }

        [Column("pro_num")]
        [StringLength(100)]
        public string NomProduit { get; set; } = null!;

        [Column("pro_description")]
        [StringLength(1000)]
        public string? DescriptionProduit { get; set; }

        [Column("comp_id")]
        public int? IdCompetition { get; set; }

        [Column("pay_num")]
        public int? NumPays { get; set; }



        [ForeignKey(nameof(NumPays))]
        [InverseProperty("NumPays")]
        public virtual Pays Pays { get; set; } = null!;

        [ForeignKey(nameof(NumCategorie))]
        [InverseProperty("NumCategorie")]
        public virtual Categorie Categorie { get; set; } = null!;

        [ForeignKey(nameof(IdCompetition))]
        [InverseProperty("IdCompetition")]
        public virtual Competition Competition { get; set; } = null!;

        [ForeignKey(nameof(GenreId))]
        [InverseProperty("gen_id")]
        public virtual Genre Genre { get; set; } = null!;

        [InverseProperty("PremierProduit")]
        public virtual ICollection<Produit_Similaire> ProduitSimilaire { get; set; } = new HashSet<Produit_Similaire>();

        [InverseProperty(nameof(Devis.ProduitDevis))]
        public virtual ICollection<Devis> DevisProduit { get; set; } = new HashSet<Devis>();

        /*[InverseProperty(nameof(Devis.Produit))]
        public virtual ICollection<Devis> ProduitDevis { get; set; } = new HashSet<Devis>();*/
    }
}
