﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_document_ldc")]
    public class Like_Document
    {

        [Key]
        [Column("doc_id")]
        public int DocumentId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }



        [ForeignKey(nameof(DocumentId))]
        [InverseProperty("Likes_blog")]
        public virtual Document Document { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("Likes_blog")]
        public virtual Utilisateur Utilisateur { get; set; } = null!;

    }
}
