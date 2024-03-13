using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_anecdote_anc")]
    public class Anecdote
    {
        [Key]
        [Column("anc_id")]
        public int Id { get; set; }

        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Column("anc_question")]
        public string Question { get; set; } = null!;

        [Column("anc_reponse")]
        public string Reponse { get; set; } = null!;
    }
}
