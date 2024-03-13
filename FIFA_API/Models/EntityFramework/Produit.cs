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


        #region Foreign Key
        [ForeignKey(nameof(NumPays))]
        [InverseProperty("NumPays")]
        public virtual Pays Pays { get; set; } = null!;

        [ForeignKey(nameof(NumCategorie))]
        [InverseProperty(nameof(Categorie.CategorieId))]
        public virtual Categorie CategorieNavigation { get; set; } = null!;

        [ForeignKey(nameof(IdCompetition))]
        [InverseProperty(nameof(Competition.ProduitsCompetition))]
        public virtual Competition CompetitionProduit { get; set; } = null!;

        [ForeignKey(nameof(GenreId))]
        [InverseProperty(nameof(Genre.ProduitsGenre))]
        public virtual Genre GenreProduit { get; set; } = null!;

        #endregion

        [InverseProperty("PremierProduit")]
        public virtual ICollection<ProduitSimilaire> ProduitSimilaire { get; set; } = new HashSet<ProduitSimilaire>();

        [InverseProperty(nameof(Devis.ProduitDevis))]
        public virtual ICollection<Devis> DevisProduit { get; set; } = new HashSet<Devis>();

        /*[InverseProperty(nameof(Devis.Produit))]
        public virtual ICollection<Devis> ProduitDevis { get; set; } = new HashSet<Devis>();*/
    }
}
