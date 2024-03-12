using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_formulaireaide_foa")]
    public partial class FormulaireAide
    {
        [Key]
        [Column("foa_id")]
        public int IdFormulaire { get; set; }

        [Required]
        [Column("foa_numaction")]
        public int NumAction { get; set; }

        [Required]
        [Column("utl_id")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("utl_nom")]
        [StringLength(50)]
        public string NomUtilisateur { get; set; } = null!;

        [Required]
        [Column("foa_telephone")]
        [StringLength(10)]
        public string Telephone { get; set; } = null!;

        [Required]
        [Column("foa_question")]
        [StringLength(250)]
        public string Question { get; set; } = null!;

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("FormulaireAide")]
        public virtual Utilisateur Utilisateur { get; set; } = null!;

        [ForeignKey(nameof(NumAction))]
        [InverseProperty("FormulaireAide")]
        public virtual Action Action { get; set; } = null!;
    }
}
