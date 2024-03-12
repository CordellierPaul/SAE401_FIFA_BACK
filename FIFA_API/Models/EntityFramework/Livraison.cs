using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace FIFA_API.Models.EntityFramework
{
    public class Livraison
    {

        [Key]
        [Column("numlivraison")]
        public int NumLivraison { get; set; }

        [Column("typelivraison")]
        public string TypeLivraison { get; set; }

        [Column("prixlivraison")]
        public double PrixLivraison { get; set; }




    }
}
