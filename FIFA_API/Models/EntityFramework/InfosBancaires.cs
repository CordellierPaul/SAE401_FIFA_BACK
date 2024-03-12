using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_infos_bancaires_inb")]
    public partial class InfosBancaires
    {
        [Key]
        [Column("utl_id")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("inb_numcarte")]
        [StringLength(228)]
        public string NumCarte { get; set; } = null!;

        [Required]
        [Column("inb_nomcarte")]
        [StringLength(30)]
        public string NomCarte { get; set; } = null!;

        [Required]
        [Column("inb_moisexpiration")]
        [StringLength(2)]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Le mois d'expiration doit être compris entre 01 et 12")]
        public string MoisExpiration { get; set; } = null!;

        [Required]
        [Column("inb_anneeexpiration")]
        [StringLength(2)]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "L'année d'expiration doit être au format YY")]
        [Range(0, 99, ErrorMessage = "L'année d'expiration doit être comprise entre 00 et 99")]
        public string AnneeExpiration { get; set; } = null!;

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("InfosBancaires")]
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
