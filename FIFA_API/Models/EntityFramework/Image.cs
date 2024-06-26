﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_image_img")]
    public partial class Image
    {
        [Key]
        [Column("img_id")]
        public int ImageId { get; set; }

        [Column("img_url")]
        public string ImageUrl { get; set; } = null!;

        [ForeignKey(nameof(ImageUrl))]
        [InverseProperty(nameof(Media.ImagesMedia))]
        public virtual Media MediaImage { get; set; } = null!;

        [InverseProperty(nameof(AlbumImage.ImageNavigation))]
        public virtual ICollection<AlbumImage> LiensAlbums { get; set; } = new HashSet<AlbumImage>();

        [InverseProperty(nameof(BlogImage.ImageNavigation))]
        public virtual ICollection<BlogImage> LiensBlogs { get; set; } = new HashSet<BlogImage>();

        [InverseProperty(nameof(ImageJoueur.ImageNavigation))]
        public virtual ICollection<ImageJoueur> LiensJoueurs { get; set; } = new HashSet<ImageJoueur>();

        [InverseProperty(nameof(ImageVariante.ImageNavigation))]
        public virtual ICollection<ImageVariante> ImagesVariante { get; set; } = new HashSet<ImageVariante>(); 
    }
}
