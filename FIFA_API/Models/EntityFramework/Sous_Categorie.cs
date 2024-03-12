using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_sous_categorie_soucat")]
    public partial class Sous_Categorie
    {
        [Key]
        [Column("cat_parent")]
        public int CategorieParent { get; set; }

        [Key]
        [Column("cat_enfant")]
        public int CategorieEnfant { get; set; }



        [ForeignKey(nameof(CategorieEnfant))]
        [InverseProperty("NumCategorie")]
        public virtual Categorie ObjCategorieEnfant { get; set; }


        [ForeignKey(nameof(CategorieParent))]
        [InverseProperty("NumCategorie")]
        public virtual Categorie ObjCategorieParent { get; set; }
    }
}
