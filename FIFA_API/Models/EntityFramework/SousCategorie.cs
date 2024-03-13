using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_sous_categorie_soucat")]
    public partial class SousCategorie
    {
        [Key]
        [Column("cat_parent")]
        public int CategorieParent { get; set; }

        [Key]
        [Column("cat_enfant")]
        public int CategorieEnfant { get; set; }



        [ForeignKey(nameof(CategorieEnfant))]
        [InverseProperty(nameof(Categorie.EnfantsCategorie))]
        public virtual Categorie ObjCategorieEnfant { get; set; }


        [ForeignKey(nameof(CategorieParent))]
        [InverseProperty(nameof(Categorie.ParentsCategorie))]
        public virtual Categorie ObjCategorieParent { get; set; }
    }
}
