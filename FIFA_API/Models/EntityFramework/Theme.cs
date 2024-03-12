using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_theme_the")]
    public partial class Theme
    {
        [Key]
        [Column("the_num")]
        public int NumTheme { get; set; }

        [Column("the_libelle")]
        [StringLength(50)]
        public string LibelleTheme { get; set; }

    }
}
