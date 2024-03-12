using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA.Models.EntityFramework
{
    [Table("JOUEUR")]
    public partial class Joueur
    {
        [Key]
        [Column("IDJOUEUR")]
        public int IdJoueur { get; set; }

        [Required]
        [Column("DATENAISSANCE", TypeName = "date")]
        public DateTime DateNaissance { get; set; }

        [Required]
        [Column("NUMPOSTE")]
        public int NumPoste { get; set; }

        [Column("IDCLUB")]
        public int? IdClub { get; set; }

        [Required]
        [Column("IDVILLE")]
        public int IdVille { get; set; }

        [Required]
        [Column("NOMJOUEUR")]
        [StringLength(50)]
        public string NomJoueur { get; set; }

        [Required]
        [Column("PRENOMJOUEUR")]
        [StringLength(50)]
        public string PrenomJoueur { get; set; }

        [Required]
        [Column("PIED")]
        [StringLength(1)]
        public string Pied { get; set; }

        [Required]
        [Column("POIDS", TypeName = "decimal(5,2)")]
        public decimal Poids { get; set; }

        [Required]
        [Column("TAILLE")]
        public int Taille { get; set; }

        [Required]
        [Column("DESCRIPTIONJOUEUR")]
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
