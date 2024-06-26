﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_album_alb")]
    public class Album
    {
        public Album()
        {
            LiensImages = new HashSet<AlbumImage>();
        }

        [Key]
        [Column("alb_id")]
        public int AlbumId { get; set; }

        [Column("alb_date_heure", TypeName = "date")]
        public DateTime DateHeure { get; set; }

        [Column("alb_titre")]
        [StringLength(50)]
        public string AlbumTitre { get; set; } = null!;

        [Column("alb_resume")]
        [StringLength(250)]
        public string AlbumResume { get; set; }

        [InverseProperty(nameof(AlbumImage.AlbumNavigation))]
        public virtual ICollection<AlbumImage> LiensImages { get; set; }

        [InverseProperty("AlbumCommente")]
        public virtual List<Commentaire> CommentairesAlbum { get; set; } = new List<Commentaire>();


        [InverseProperty(nameof(LikeAlbum.AlbumNavigation))]
        public virtual ICollection<LikeAlbum> LikesAlbums { get; set; }
    }
}
