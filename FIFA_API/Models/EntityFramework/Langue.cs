using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("langue")]
    public class Langue
    {

        [Key]
        [Required]
        [Column("numlangue")]
        public int NumLangue { get; set;}

        [Required]
        [Column("nomlangue")]
        public string NomLangue { get; set;}


    }
}
