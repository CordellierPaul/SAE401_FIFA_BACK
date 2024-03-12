using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_action_act")]
    public partial class Action
    {
        [Key]
        [Column("act_id")]
        public int Id { get; set; }

        [Column("act_type")]
        [StringLength(100)]
        public string TypeAction { get; set; } = null!;
    }
}
