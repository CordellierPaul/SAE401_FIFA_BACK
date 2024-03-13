using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_joueur_jou")]
    public partial class Joueur
    {
        public Joueur()
        {
            LiensArticles = new HashSet<ArticleJoueur>();
            Matches_joue = new HashSet<Match_joue>();
            RemportesJoueur = new HashSet<Remporte>();
        }

        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Required]
        [Column("jou_datenaissance", TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [Column("jou_numposte")]
        public int NumPoste { get; set; }

        [Column("clb_id")]
        public int? IdClub { get; set; }

        [Required]
        [Column("vil_id")]
        public int IdVille { get; set; }

        [Required]
        [Column("jou_nom")]
        [StringLength(50)]
        public string NomJoueur { get; set; } = null!;

        [Required]
        [Column("jou_prenom")]
        [StringLength(50)]
        public string PrenomJoueur { get; set; } = null!;

        [Required]
        [Column("jou_pied")]
        [StringLength(1)]
        public string Pied { get; set; } = null!;

        [Required]
        [Column("jou_poids", TypeName = "decimal(5,2)")]
        public decimal Poids { get; set; }

        [Required]
        [Column("jou_taille")]
        public int Taille { get; set; }

        [Required]
        [Column("jou_description")]
        [StringLength(1000)]
        public string DescriptionJoueur { get; set; } = null!;

        [ForeignKey(nameof(IdVille))]
        [InverseProperty("Joueurs")]
        public virtual Ville Ville { get; set; } = null!;

        [ForeignKey(nameof(IdClub))]
        [InverseProperty("Joueurs")]
        public virtual Club Club { get; set; } = null!;

        [ForeignKey(nameof(NumPoste))]
        [InverseProperty("Joueurs")]
        public virtual Poste Poste { get; set; } = null!;

        [InverseProperty(nameof(ArticleJoueur.JoueurNavigation))]
        public virtual ICollection<ArticleJoueur> LiensArticles { get; set; }

        [InverseProperty(nameof(Match_joue.JoueurNavigation))]
        public virtual ICollection<Match_joue> Matches_joue { get; set; }

        [InverseProperty(nameof(Remporte.JoueurRemportant))]
        public virtual ICollection<Remporte> RemportesJoueur { get; set; }
        public virtual ICollection<Remporte> RemportesJoueur { get; set; } = new HashSet<Remporte>();

        [InverseProperty(nameof(ImageJoueur.JoueurNavigation))]
        public virtual ICollection<ImageJoueur> LiensImages { get; set; } = new HashSet<ImageJoueur>();
    }
}
