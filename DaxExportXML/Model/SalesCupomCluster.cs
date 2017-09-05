using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxExportXML.Model
{
    public class SalesCupomCluster
    {
        public int BatchId { get; set; }

        public string StoreId { get; set; }

        public string TerminalId { get; set; }

        public string Orig { get; set; }

        public DateTime TransDate { get; set; }

        public string ItemId { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? Quantity { get; set; }

        public decimal? LineAmount { get; set; }

        public int Status { get; set; }
    }
}
