﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace FIFA_API.Models.EntityFramework
{
    [Table("t_j_like_article_lar")]
    public class LikeArticle
    {

        [Key]
        [Column("art_id")]
        public int ArticleId { get; set; }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }



        [ForeignKey(nameof(ArticleId))]
        [InverseProperty("LikesArticles")]
        public virtual Article ArticleNavigation { get; set; } = null!;


        [ForeignKey(nameof(UtilisateurId))]
        [InverseProperty("LikesArticles")]
        public virtual Utilisateur UtilisateurNavigation { get; set; } = null!;

    }
}
