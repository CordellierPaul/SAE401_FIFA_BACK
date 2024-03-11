using Microsoft.CodeAnalysis.Differencing;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("IMAGE")]
    public partial class Image
    {
        [Key]
        [Column("URL")]
        public string Url { get; set; }

        [ForeignKey(nameof(Url))]
        [InverseProperty("ImageHeritage")]
        public virtual Media Media { get; set; }

        public Image()
        {
            Url = null!;
        }
    }
}
