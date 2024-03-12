using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("media")]
    public class Media
    {



        [Key]
        [Column("idmedia")]
        public int IdMedia { get; set; }


        [Required]
        [Column("url")]
        public string Url { get; set; }


    }
}
