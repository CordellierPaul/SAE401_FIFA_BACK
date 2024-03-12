using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_blog_blg")]
    public class Blog
    {
        [Key]
        [Column("blg_id")]
        public int Id { get; set; }

        //[Key] ?
        [Column("art_id")]
        public int IdArticle { get; set; }  // TODO lien article

        [Column("blg_dateheure")]
        public DateTime DateHeure { get; set; }


    }
}
