using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_blog")]
    public class Blog
    {
        [Key]
        [Column("blog_id")]
        public int Id { get; set; }

        // TODO
    }
}
