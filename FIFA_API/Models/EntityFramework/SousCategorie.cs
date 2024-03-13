using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_sous_categorie_sct")]
    public partial class SousCategorie
    {
        [Key]
        [Column("cat_parent")]
        public int CategorieParentId { get; set; }

        [Key]
        [Column("cat_enfant")]
        public int CategorieEnfantId { get; set; }

        [ForeignKey(nameof(CategorieEnfantId))]
        [InverseProperty(nameof(Categorie.EnfantsCategorie))]
        public virtual Categorie ObjCategorieEnfant { get; set; } = null!;

        [ForeignKey(nameof(CategorieParentId))]
        [InverseProperty(nameof(Categorie.ParentsCategorie))]
        public virtual Categorie ObjCategorieParent { get; set; } = null!;
    }
}
