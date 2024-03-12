using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_image_joueur_imj")]
    public partial class ImageJoueur
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Image))]
        public string Url { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(Joueur))]
        public int IdJoueur { get; set; }

        [ForeignKey(nameof(Url))]
        [InverseProperty("ImageJoueur")]
        public virtual Image Image { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("ImageJoueur")]
        public virtual Joueur Joueur { get; set; }
    }
}
