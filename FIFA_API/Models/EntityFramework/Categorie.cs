using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_categorie_cat")]
    public partial class Categorie
    {

        public Categorie()
        {
            EnfantsCategorie = new HashSet<SousCategorie>();
            Produits = new HashSet<Produit>();
        }

        [Key]
        [Column("cat_id")]
        public int CategorieId { get; set; }

        [Column("cat_nom")]
        [StringLength(25)]
        public string CategorieNom { get; set; } = null!;


        [InverseProperty(nameof(SousCategorie.ObjCategorieEnfant))]
        public virtual ICollection<SousCategorie> EnfantsCategorie { get; set; } = new HashSet<SousCategorie>();

        [InverseProperty(nameof(SousCategorie.ObjCategorieParent))]
        public virtual Categorie ParentCategorie { get; set; }

        [InverseProperty("Categorie")]
        public virtual ICollection<Produit> Produits { get; set; }

    }
}
