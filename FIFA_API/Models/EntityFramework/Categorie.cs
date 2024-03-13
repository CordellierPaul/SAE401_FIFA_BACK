using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_categorie_cat")]
    public partial class Categorie
    {
        [Key]
        [Column("cat_id")]
        public int CategorieId { get; set; }

        [Column("cat_nom")]
        [StringLength(25)]
        public string CategorieNom { get; set; } = null!;


        [InverseProperty(nameof(Sous_Categorie.ObjCategorieEnfant))]
        public virtual ICollection<Sous_Categorie> EnfantsCategorie { get; set; } = new HashSet<Sous_Categorie>();

        [InverseProperty(nameof(Sous_Categorie.ObjCategorieParent))]
        public virtual ICollection<Categorie> ParentsCategorie { get; set; } = new HashSet<Categorie>();
    }
}
