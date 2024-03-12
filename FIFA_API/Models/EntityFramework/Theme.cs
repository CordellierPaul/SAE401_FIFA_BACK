using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("theme")]
    public partial class Theme
    {
        [Key]
        [Column("NUMTHEME")]
        public int NumTheme { get; set; }

        [Column("LIBELLETHEME")]
        [StringLength(50)]
        public string LibelleTheme { get; set; }

    }
}
