using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("FORMULAIRE_AIDE")]
    public partial class FormulaireAide
    {
        [Key]
        [Column("IDFORMULAIRE")]
        public int IdFormulaire { get; set; }

        [Required]
        [Column("NUMACTION")]
        public int NumAction { get; set; }

        [Required]
        [Column("IDUTILISATEUR")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("NOMUTILISATEUR")]
        [StringLength(50)]
        public string NomUtilisateur { get; set; }

        [Required]
        [Column("TELEPHONE")]
        [StringLength(10)]
        public string Telephone { get; set; }

        [Required]
        [Column("QUESTION")]
        [StringLength(250)]
        public string Question { get; set; }

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("FormulaireAide")]
        public virtual Utilisateur Utilisateur { get; set; }

        [ForeignKey(nameof(NumAction))]
        [InverseProperty("FormulaireAide")]
        public virtual Action Action { get; set; }
    }
}
