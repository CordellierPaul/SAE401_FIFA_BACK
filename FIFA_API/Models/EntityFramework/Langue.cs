using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("langue")]
    public class Langue
    {

        [Key]
        [Column("numlangue")]
        public int NumLangue { get; set;}

        [Column("nomlangue")]
        public string NomLangue { get; set;}


    }
}
