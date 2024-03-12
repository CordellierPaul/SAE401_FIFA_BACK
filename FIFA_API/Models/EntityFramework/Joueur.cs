using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_joueur_jou")]
    public partial class Joueur
    {
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
        public string NomJoueur { get; set; }

        [Required]
        [Column("jou_prenom")]
        [StringLength(50)]
        public string PrenomJoueur { get; set; }

        [Required]
        [Column("jou_pied")]
        [StringLength(1)]
        public string Pied { get; set; }

        [Required]
        [Column("jou_poids", TypeName = "decimal(5,2)")]
        public decimal Poids { get; set; }

        [Required]
        [Column("jou_taille")]
        public int Taille { get; set; }

        [Required]
        [Column("jou_description")]
        [StringLength(1000)]
        public string DescriptionJoueur { get; set; }

        [ForeignKey(nameof(IdVille))]
        [InverseProperty("Joueurs")]
        public virtual Ville Ville { get; set; }

        [ForeignKey(nameof(IdClub))]
        [InverseProperty("Joueurs")]
        public virtual Club Club { get; set; }

        [ForeignKey(nameof(NumPoste))]
        [InverseProperty("Joueurs")]
        public virtual Poste Poste { get; set; }
    }
}
