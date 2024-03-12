using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_match")]
    public class Match
    {

        [Key]
        [Column("idmatch")]
        public int IdMatch { get; set; }


        [Column("idclubdomicile")]
        public int IdClubDomicile { get; set; }

        [Column("idclubexterieur")]
        public int IdClubExterieur { get; set; }

        [Column("datematch")]
        public DateTime DateMatch { get; set; }

        [Column("scoredomicile")]
        public int ScoreDomicile { get; set; }

        [Column("ScoreExterieur")]
        public int ScoreExterieur { get; set; }





        [ForeignKey(nameof(IdClubDomicile))]
        [InverseProperty("Matches")]
        public virtual Club ClubDomicile { get; set; }


        [ForeignKey(nameof(IdClubExterieur))]
        [InverseProperty("Matches")]
        public virtual Club ClubExterieur { get; set; }



    }
}
