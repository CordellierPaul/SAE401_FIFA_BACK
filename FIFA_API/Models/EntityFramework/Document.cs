using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_document_doc")]
    [Microsoft.EntityFrameworkCore.Index(nameof(DocumentLienPdf), Name = "uq_doc_lienpdf", IsUnique = true)]
    public partial class Document
    {
        [Key]
        [Column("doc_id")]
        public int DocumentId { get; set; }

        [Required]
        [Column("doc_dateheure", TypeName = "date")]
        public DateTime DocumentDateHeure { get; set; }

        [Required]
        [Column("doc_titre")]
        [StringLength(50)]
        public string DocumentTitre { get; set; } = null!;

        [Required]
        [Column("doc_resume")]
        [StringLength(250)]
        public string DocumentResume { get; set; } = null!;

        [Required]
        [Column("doc_lienpdf")]
        [StringLength(100)]
        [RegularExpression(@"\.pdf$", ErrorMessage = "Le lien PDF doit se terminer par l'extension .pdf")]
        public string DocumentLienPdf { get; set; } = null!;


        [InverseProperty("DocumentCommente")]
        public virtual List<Commentaire> CommentairesDocument { get; set; } = new List<Commentaire>();


        [InverseProperty(nameof(LikeDocument.DocumentNavigation))]
        public virtual ICollection<LikeDocument> LikesDocuments { get; set; } = new List<LikeDocument>();

    }
}
