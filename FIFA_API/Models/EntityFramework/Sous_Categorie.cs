using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("sous_categorie")]
    public partial class Sous_Categorie
    {
        [Key]
        [Column("CATEGORIEPARENT")]
        public int CategorieParent { get; set; }

        [Key]
        [Column("CATEGORIEENFANT")]
        public int CategorieEnfant { get; set; }

    }
}
