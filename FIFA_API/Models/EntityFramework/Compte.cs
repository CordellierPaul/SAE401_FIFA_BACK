using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_compte_cpt")]
    public partial class Compte
    {
        [Key]
        [Column("cpt_id")]
        public int CompteId { get; set; }

        [Column("cpt_email")]
        [StringLength(100)]
        public string CompteEmail { get; set; } = null!;

        [Column("cpt_login")]
        [StringLength(50)]
        public string Comptelogin { get; set; } = null!;

        [Column("cpt_mdp", TypeName = "char(128)")]
        public string CompteMdp { get; set; } = null!;

        [Column("cpt_dateconnexion")]
        public DateTime CompteDateConnexion { get; set; }

        [Column("cpt_annonces")]
        public bool CompteAnnonces { get; set; } = false;

        [Column("cpt_offres")]
        public bool CompteOffres { get; set; } = false;

        [Column("cpt_typecompte")]
        public int TypeCompte { get; set; }

        // UtilisateurCompte est nullable car un compte n'a pas obligatoirement d'utilisateur
        [InverseProperty(nameof(Utilisateur.CompteUtilisateur))]
        public virtual Utilisateur? UtilisateurCompte { get; set; }
    }
}
