﻿using FIFA_API.Models.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_vote_vot")]
    public partial class Vote
    {
        [Key]
        [Column("utl_id")]
        public int IdUtilisateur { get; set; }

        [Key]
        [Column("the_num")]
        public int NumTheme { get; set; }

        [Key]
        [Column("jou_id")]
        public int IdJoueur { get; set; }

        [Required]
        [Column("vot_note")]
        public int Note { get; set; }

        [ForeignKey(nameof(IdUtilisateur))]
        [InverseProperty("Votes")]
        public virtual Utilisateur Utilisateur { get; set; }

        [ForeignKey(nameof(NumTheme))]
        [InverseProperty("Votes")]
        public virtual Theme Theme { get; set; }

        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("Votes")]
        public virtual Joueur Joueur { get; set; }
    }
}