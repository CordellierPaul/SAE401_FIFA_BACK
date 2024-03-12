using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FIFA_API.Models.EntityFramework
{
    [Table("match_joue")]
    public class Match_joue
    {

        [Key]
        [Column("idjoueur")]
        public int IdJoueur { get; set; }

        [Key]
        [Column("idmatch")]
        public int IdMatch { get; set; }


        [Column("nbbuts")]
        public int nbButs { get; set; }

        [Column("nbminutes")]
        public int nbminutes { get; set; }

        [Column("titularisation")]
        public string Titularisation { get; set; }

        [Column("selection")]
        public string Selection { get; set; }




        [ForeignKey(nameof(IdJoueur))]
        [InverseProperty("Matches_joue")]
        public virtual Joueur Joueur { get; set; }


        [ForeignKey(nameof(IdMatch))]
        [InverseProperty("Matches_joue")]
        public virtual Match Match { get; set; }



    }
}
