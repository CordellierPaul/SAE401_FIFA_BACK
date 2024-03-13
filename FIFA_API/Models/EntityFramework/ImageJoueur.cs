using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_image_joueur_imj")]
    public partial class ImageJoueur
    {
        [Key]
        [ForeignKey("")]
        public int ImageId { get; set; }

        [Key]
        [ForeignKey("jou_id")]
        public int JoueurId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty("ImageJoueur")]
        public virtual Image Image { get; set; } = null!;

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty("ImageJoueur")]
        public virtual Joueur Joueur { get; set; } = null!;
    }
}
