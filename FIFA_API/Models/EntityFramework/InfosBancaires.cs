using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA.Models.EntityFramework
{
    [Table("INFOS_BANCAIRES")]
    public partial class InfosBancaires
    {
        [Key]
        [Column("IDUTILISATEUR")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("NUMCARTE")]
        [StringLength(228)]
        public string NumCarte { get; set; }

        [Required]
        [Column("NOMCARTE")]
        [StringLength(30)]
        public string NomCarte { get; set; }

        [Required]
        [Column("MOISEXPIRATION")]
        [StringLength(2)]
        [RegularExpression(@"^(0[1-9]|1[0-2])$", ErrorMessage = "Le mois d'expiration doit être compris entre 01 et 12")]
        public string MoisExpiration { get; set; }

        [Required]
        [Column("ANNEEEXPIRATION")]
        [StringLength(2)]
        [RegularExpression(@"^\d{2}$", ErrorMessage = "L'année d'expiration doit être au format YY")]
        [Range(0, 99, ErrorMessage = "L'année d'expiration doit être comprise entre 00 et 99")]
        public string AnneeExpiration { get; set; }

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("InfosBancaires")]
        public virtual Utilisateur Utilisateur { get; set; }
    }
}
