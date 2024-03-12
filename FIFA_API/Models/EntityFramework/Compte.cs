using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_compte_cpte")]
    public partial class Compte
    {
        [Key]
        [Column("cpte_id")]
        public int CompteId { get; set; }

        [Column("cpte_email")]
        [StringLength(100)]
        public string CompteEmail { get; set; } = null!;

        [Column("cpte_login")]
        [StringLength(50)]
        public string Comptelogin { get; set; } = null!;

        [Column("cpte_mdp", TypeName = "char(128)")]
        public string? CompteMdp { get; set; } = null!;

        [Column("cpte_dateconnexion")]
        public DateTime CompteDateConnexion { get; set; } = DateTime.Now;

        [Column("cpte_annonces")]
        public bool CompteAnnonces { get; set; } = false;

        [Column("cpte_offres")]
        public bool CompteOffres { get; set; } = false;


    }
}
