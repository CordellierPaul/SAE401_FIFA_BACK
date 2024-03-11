using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    public partial class Action
    {
        [Key]
        [Column("nomAction")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column]
        [StringLength(100)]
        public string TypeAction { get; set; } = null!;
    }
}
