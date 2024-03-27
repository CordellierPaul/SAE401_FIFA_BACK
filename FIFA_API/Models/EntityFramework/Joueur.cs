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
            Matches_joue = new HashSet<MatchJoue>();
            RemportesJoueur = new HashSet<Remporte>();
        }

        [Key]
        [Column("jou_id")]
        public int JoueurId { get; set; }

        [Required]
        [Column("jou_datenaissance", TypeName = "date")]
        public DateTime JoueurDateNaissance { get; set; }

        [Required]
        [Column("pos_id")]
        public int PosteId { get; set; }

        [Column("clb_id")]
        public int? ClubId { get; set; }

        [Required]
        [Column("vil_id")]
        public int VilleId { get; set; }

        [Required]
        [Column("jou_nom")]
        [StringLength(50)]
        public string JoueurNom { get; set; } = null!;

        [Required]
        [Column("jou_prenom")]
        [StringLength(50)]
        public string JoueurPrenom { get; set; } = null!;

        [Required]
        [Column("jou_pied")]
        [StringLength(1)]
        public string JoueurPied { get; set; } = null!;

        [Required]
        [Column("jou_poids", TypeName = "decimal(5,2)")]
        public decimal JoueurPoids { get; set; }

        [Required]
        [Column("jou_taille")]
        public int JoueurTaille { get; set; }

        [Required]
        [Column("jou_description")]
        [StringLength(1000)]
        public string JoueurDescription { get; set; } = null!;

        #region Foreign keys

        [ForeignKey(nameof(VilleId))]
        [InverseProperty(nameof(Ville.JoueursVille))]
        public virtual Ville VilleJoueur { get; set; } = null!;

        [ForeignKey(nameof(ClubId))]
        [InverseProperty(nameof(Club.JoueursClub))]
        public virtual Club ClubJoueur { get; set; } = null!;

        [ForeignKey(nameof(PosteId))]
        [InverseProperty(nameof(Poste.JoueursPoste))]
        public virtual Poste PosteJoueur { get; set; } = null!;

        #endregion

        [InverseProperty(nameof(ArticleJoueur.JoueurNavigation))]
        public virtual ICollection<ArticleJoueur> LiensArticles { get; set; }

        [InverseProperty(nameof(MatchJoue.JoueurNavigation))]
        public virtual ICollection<MatchJoue> Matches_joue { get; set; }

        [InverseProperty(nameof(Remporte.JoueurRemportant))]
        public virtual ICollection<Remporte> RemportesJoueur { get; set; } = new HashSet<Remporte>();

        [InverseProperty(nameof(ImageJoueur.JoueurNavigation))]
        public virtual ICollection<ImageJoueur> LiensImages { get; set; } = new HashSet<ImageJoueur>();

        [InverseProperty(nameof(Anecdote.JoueurNavigation))]
        public virtual ICollection<Anecdote> LienAnecdotes { get; set; } = new HashSet<Anecdote>();

        [InverseProperty(nameof(Vote.JoueurVote))]
        public virtual ICollection<Vote> VotesJoueur { get; set; } = new HashSet<Vote>();

        [InverseProperty(nameof(JoueurTheme.JoueurNavigation))]
        public virtual ICollection<JoueurTheme> LienTheme { get; set; } = new HashSet<JoueurTheme>();
    }
}
