﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_adresse_adr")]
    public class Adresse
    {
        [Key]
        [Column("adr_id")]
        public int Id { get; set; }

        [Column("adr_rue")] 
        [StringLength(100)]
        public string Rue { get; set; } = null!;

        // TODO une fois que la table ville sera créée, je m'occuperai de faire le lien entre ville et adresse (c'est Paul qui écrit)
        public int IdVille { get; set; }


        [InverseProperty(nameof(Commande.AdresseCommande))]
        public virtual ICollection<Commande> CommandesAdresse { get; set; } = new HashSet<Commande>();

        [InverseProperty(nameof(Utilisateur.AdresseUtilisateur))]
        public virtual ICollection<Utilisateur> UtilisateursAdresse { get; set; } = new HashSet<Utilisateur>();
    }
}
