using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("like_album")]
    public class Like_Album
    {

        [Key]
        [Column("idalbum")]
        public int IdAlbum { get; set; }

        [Key]
        [Column("adutilisateur")]
        public int IdUtilisateur { get; set; }

        //rajouter les clés étrangeres


    }
}
