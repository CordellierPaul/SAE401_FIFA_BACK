using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_anecdote_anec")]
    public class Anecdote
    {
        [Key]
        [Column("anec_id")]
        public int Id { get; set; }

        // TODO lier à joueur
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Column("anec_question")]
        public string Question { get; set; } = null!;

        [Column("anec_reponse")]
        public string Reponse { get; set; } = null!;
    }
}
