﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_ville_vil")]
    public partial class Ville
    {

        public Ville()
        {
            Produits = new HashSet<Ville>();
        }

        [Key]
        [Column("vil_id")]
        public int IdVille { get; set; }

        [Column("pay_id")]
        public int NumPays { get; set; }

        [Column("vil_nom")]
        [StringLength(50)]
        public string NomVille { get; set; } = null!;

        [Column("vil_codepostal", TypeName = "char(5)")]
        public char CodePostal { get; set; }


        [ForeignKey(nameof(NumPays))]
        [InverseProperty("NumPays")]
        public virtual Pays Pays{ get; set; } = null!;


    }
}
