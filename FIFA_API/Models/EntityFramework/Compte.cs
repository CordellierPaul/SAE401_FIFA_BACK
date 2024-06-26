﻿using System.ComponentModel.DataAnnotations;
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
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être entre 6 et 100 caractères.")]
        [EmailAddress(ErrorMessage = "Le format de l'e-mail n'est pas correct.")]
        public string CompteEmail { get; set; } = null!;

        [Column("cpt_login")]
        [StringLength(50)]
        public string? Comptelogin { get; set; }

        [Column("cpt_mdp")]
        [StringLength(128, ErrorMessage = "La longueur du mot de passe hashé doit être inférieure ou égale à 128 caractères")]
        public string CompteMdp { get; set; } = null!;

        [Column("cpt_dateconnexion")]
        public DateTime CompteDateConnexion { get; set; }

        [Column("cpt_annonces")]
        public bool CompteAnnonces { get; set; }

        [Column("cpt_typecompte")]
        public int TypeCompte { get; set; }

        // UtilisateurCompte est nullable car un compte n'a pas obligatoirement d'utilisateur
        [InverseProperty(nameof(Utilisateur.CompteUtilisateur))]
        public virtual Utilisateur? UtilisateurCompte { get; set; }
    }
}
