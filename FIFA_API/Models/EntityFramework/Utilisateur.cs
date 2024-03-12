using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;
using System.Xml.Linq;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    [Index(nameof(TelAcheteur), Name = "uq_utl_telacheteur", IsUnique = true)]
    [Index(nameof(NumTva), Name = "uq_utl_numtva", IsUnique = true)]
    [Index(nameof(NumSociete), Name = "uq_utl_numSociete", IsUnique = true)]
    [Index(nameof(IdCompte), Name = "uq_utl_idcompte", IsUnique = true)]
    public partial class Utilisateur
    {
        [Key]
        [Column("utl_id")]
        public int IdUtilisateur { get; set; }

        [Required]
        [Column("utl_prenom")]
        [StringLength(50)]
        public string PrenomUtilisateur { get; set; }

        [Column("adr_id")]
        public int? IdAdresse { get; set; }

        [Column("utl_datenaissance", TypeName = "date")]
        [Required]
        public DateTime DateNaissance { get; set; }

        [Column("com_id")]
        public int? IdCompte { get; set; }

        [Column("mon_nummonnaie")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de monnaie doit être supérieur ou égal à 1")]
        public int NumMonnaie { get; set; } = 1;

        [Column("lan_num")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Le numéro de langue doit être supérieur ou égal à 1")]
        public int NumLangue { get; set; } = 1;

        [Column("utl_paysnaissance")]
        [Required]
        public int PaysNaissance { get; set; }

        [Column("utl_paysfavori")]
        [Required]
        public int PaysFavori { get; set; }

        [Column("utl_nomacheteur")]
        [StringLength(50)]
        public string NomAcheteur { get; set; }

        [Column("utl_telacheteur")]
        [StringLength(10)]
        public string TelAcheteur { get; set; }

        [Column("act_id")]
        public int? IdActivite { get; set; }

        [Column("soc_num")]
        [StringLength(14)]
        public string NumSociete { get; set; }

        [Column("utl_numtva")]
        [StringLength(11)]
        public string NumTva { get; set; }

        [ForeignKey(nameof(IdAdresse))]
        [InverseProperty("Utilisateurs")]
        public virtual Adresse Adresse { get; set; }

        [ForeignKey(nameof(IdCompte))]
        [InverseProperty("Utilisateurs")]
        public virtual Compte Compte { get; set; }

        [ForeignKey(nameof(NumLangue))]
        [InverseProperty("Utilisateurs")]
        public virtual Langue Langue { get; set; }

        [ForeignKey(nameof(IdActivite))]
        [InverseProperty("Utilisateurs")]
        public virtual Activite Activite { get; set; }

        [ForeignKey(nameof(PaysFavori))]
        [InverseProperty("UtilisateursPaysFavori")]
        public virtual Pays PaysFavoriNavigation { get; set; }

        [ForeignKey(nameof(PaysNaissance))]
        [InverseProperty("UtilisateursPaysNaissance")]
        public virtual Pays PaysNaissanceNavigation { get; set; }

        [ForeignKey(nameof(NumMonnaie))]
        [InverseProperty("Utilisateurs")]
        public virtual Monnaie Monnaie { get; set; }
    }
}
