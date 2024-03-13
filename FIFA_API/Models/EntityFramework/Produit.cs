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

        [Column("pro_nom")]
        [StringLength(100)]
        public string NomProduit { get; set; } = null!;

        [Column("pro_description")]
        [StringLength(1000)]
        public string? DescriptionProduit { get; set; }

        [Column("comp_id")]
        public int? IdCompetition { get; set; }

        [Column("pay_num")]
        public int NumPays { get; set; }


        #region Foreign Key
        [ForeignKey(nameof(NumPays))]
        [InverseProperty(nameof(Pays.ProduitsPays))]
        public virtual Pays PaysProduit { get; set; } = null!;

        [ForeignKey(nameof(NumCategorie))]
        [InverseProperty(nameof(Categorie.ProduitsCategorie))]
        public virtual Categorie CategorieNavigation { get; set; } = null!;

        [ForeignKey(nameof(IdCompetition))]
        [InverseProperty(nameof(Competition.ProduitsCompetition))]
        public virtual Competition CompetitionProduit { get; set; } = null!;

        [ForeignKey(nameof(GenreId))]
        [InverseProperty(nameof(Genre.ProduitsGenre))]
        public virtual Genre GenreProduit { get; set; } = null!;

        #endregion

        #region Inverse Property

        [InverseProperty(nameof(ProduitSimilaire.PremierProduit))]
        public virtual ICollection<ProduitSimilaire> ProduitSimilaireLienUn { get; set; } = new HashSet<ProduitSimilaire>();

        [InverseProperty(nameof(ProduitSimilaire.DeuxiemeProduit))]
        public virtual ICollection<ProduitSimilaire> ProduitSimilaireLienDeux { get; set; } = new HashSet<ProduitSimilaire>();

        [InverseProperty(nameof(Devis.ProduitDevis))]
        public virtual ICollection<Devis> DevisProduit { get; set; } = new HashSet<Devis>();


        [InverseProperty(nameof(CaracteristiqueProduit.ProduitNavigation))]
        public virtual ICollection<CaracteristiqueProduit> LienCaracteristiques { get; set; } = new HashSet<CaracteristiqueProduit>();

        [InverseProperty(nameof(VarianteProduit.ProduitVariante))]
        public virtual ICollection<VarianteProduit> VariantesProduit { get; set; } = new HashSet<VarianteProduit>();

        #endregion
    }
}
