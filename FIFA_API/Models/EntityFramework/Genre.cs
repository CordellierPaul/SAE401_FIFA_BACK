using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("GENRE")]
    public partial class Genre
    {
        [Key]
        [Column("NUMGENRE")]
        public int NumGenre { get; set; }

        [Required]
        [Column("GENRE")]
        [StringLength(10)]
        public string GenreName { get; set; }
    }
}
