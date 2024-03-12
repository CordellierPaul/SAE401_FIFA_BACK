﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_article_art")]
    public class Article
    {
        public Article()
        {
            LiensJoueur = new HashSet<ArticleJoueur>();
        }

        [Key]
        [Column("art_id")]
        public int Id { get; set; }

        [Column("art_dateheure")]
        public DateTime DateHeure { get; set; }

        [Column("art_titre")]
        public string Titre { get; set; } = null!;

        [Column("art_resume")]
        public string Resume { get; set; } = null!;

        [Column("art_texte")]
        public string Texre { get; set; } = null!;

        [InverseProperty(nameof(ArticleJoueur.ArticleNavigation))]
        public virtual ICollection<ArticleJoueur> LiensJoueur { get; set; }
    }
}
