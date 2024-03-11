using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FIFA_API.Models.EntityFramework
{
    [Table("DOCUMENT")]
    [Index(nameof(LienPdf), Name = "uq_document_lienpdf", IsUnique = true)]
    public partial class Document
    {
        [Key]
        [Column("IDPUBLICATION")]
        public int IdPublication { get; set; }

        [Required]
        [Column("DATEHEURE", TypeName = "date")]
        public DateTime DateHeure { get; set; }

        [Required]
        [Column("TITRE")]
        [StringLength(50)]
        public string Titre { get; set; }

        [Required]
        [Column("RESUME")]
        [StringLength(250)]
        public string Resume { get; set; }

        [Required]
        [Column("LIENPDF")]
        [StringLength(100)]
        [RegularExpression(@"\.pdf$", ErrorMessage = "Le lien PDF doit se terminer par l'extension .pdf")]
        public string LienPdf { get; set; }

        public Document()
        {
            LienPdf = null!;
        }
    }
}
