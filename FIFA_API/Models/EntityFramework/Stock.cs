﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FIFA_API.Models.EntityFramework
{
    [Table("t_e_stock_stk")]
    public class Stock
    {
        [Key]
        [Column("stk_id")]
        public int StockId { get; set; }

        [Column("tai_id")]
        public int TailleId { get; set; }

        [Column("vpd_id")]
        public int VarianteProduitId { get; set; }

        [Column("stk_quantitestockee")]
        public int QuantiteStockee { get; set; }


        [ForeignKey(nameof(TailleId))]
        [InverseProperty(nameof(Taille.StocksTaille))]
        public virtual Taille TailleStockee { get; set; } = null!;

        [ForeignKey(nameof(VarianteProduitId))]
        [InverseProperty(nameof(VarianteProduit.StocksVariante))]
        public virtual VarianteProduit? VarianteStockee { get; set; } = null!;
    }
}
