using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_image_joueur_imj")]
    public partial class ImageJoueur
    {
        [Key]
        [ForeignKey("img_id")]
        public int ImageId { get; set; }

        [Key]
        [ForeignKey("jou_id")]
        public int JoueurId { get; set; }

        [ForeignKey(nameof(ImageId))]
        [InverseProperty(nameof(Image.LiensJoueurs))]
        public virtual Image ImageNavigation { get; set; } = null!;

        [ForeignKey(nameof(JoueurId))]
        [InverseProperty(nameof(Joueur.LiensImages))]
        public virtual Joueur JoueurNavigation { get; set; } = null!;
    }
}
