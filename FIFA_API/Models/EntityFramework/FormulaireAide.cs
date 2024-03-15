using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_formulaireaide_foa")]
    public partial class FormulaireAide
    {
        [Key]
        [Column("foa_id")]
        public int FormulaireAideId { get; set; }

        [Required]
        [Column("act_id")]
        public int ActionId { get; set; }

        [Required]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Required]
        [Column("foa_nom")]
        [StringLength(50)]
        public string UtilisateurNom { get; set; } = null!;

        [Required]
        [Column("foa_telephone")]
        [StringLength(10)]
        public string FormulaireAideTelephone { get; set; } = null!;

        [Required]
        [Column("foa_question")]
        [StringLength(250)]
        public string Question { get; set; } = null!;

        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateur.FormulairesAideUtilisateur))]
        public virtual Utilisateur UtilisateurDuFormulaire { get; set; } = null!;

        [ForeignKey(nameof(ActionId))]
        [InverseProperty(nameof(Action.ActionFormulaireAide))]
        public virtual Action FormulaireAction { get; set; } = null!;
    }
}
