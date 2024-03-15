using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_langue_lng")]
    public class Langue
    {

        [Key]
        [Required]
        [Column("lng_id")]
        public int LangueId { get; set;}

        [Required]
        [StringLength(25)]
        [Column("lng_nom")]
        public string LangueNom { get; set;} = null!;


        [InverseProperty(nameof(Utilisateur.LangueUtilisateur))]
        public virtual ICollection<Utilisateur> UtilisateursLangue { get; set; } = new HashSet<Utilisateur>();


    }
}
