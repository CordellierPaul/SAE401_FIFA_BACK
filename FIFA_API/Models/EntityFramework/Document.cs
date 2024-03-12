using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_document_doc")]
    [Index(nameof(LienPdf), Name = "uq_doc_lienpdf", IsUnique = true)]
    public partial class Document
    {
        [Key]
        [Column("pub_id")]
        public int IdPublication { get; set; }

        [Required]
        [Column("doc_dateheure", TypeName = "date")]
        public DateTime DateHeure { get; set; }

        [Required]
        [Column("doc_titre")]
        [StringLength(50)]
        public string Titre { get; set; }

        [Required]
        [Column("doc_resume")]
        [StringLength(250)]
        public string Resume { get; set; }

        [Required]
        [Column("doc_lienpdf")]
        [StringLength(100)]
        [RegularExpression(@"\.pdf$", ErrorMessage = "Le lien PDF doit se terminer par l'extension .pdf")]
        public string LienPdf { get; set; }



        [InverseProperty("DocumentCommente")]
        public virtual List<Commentaire> CommentairesDocument { get; set; } = new List<Commentaire>();

        public Document()
        {
            LienPdf = null!;
        }
    }
}
