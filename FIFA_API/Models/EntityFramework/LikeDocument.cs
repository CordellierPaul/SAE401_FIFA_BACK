﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_document_ldc")]
    public class LikeDocument
    {
        [Key]
        [Column("doc_id")]
        public int DocumentId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }


        [ForeignKey(nameof(DocumentId))]
        [InverseProperty(nameof(Document.LikesDocuments))]
        public virtual Document DocumentNavigation { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty(nameof(Utilisateur.LikesDocuments))]
        public virtual Utilisateur UtilisateurNavigation { get; set; } = null!;
    }
}
