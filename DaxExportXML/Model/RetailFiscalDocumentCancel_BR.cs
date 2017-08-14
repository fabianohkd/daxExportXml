using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxExportXML.Model
{
    public class RetailFiscalDocumentCancel_BR
    {
        public string ACCESSKEY { get; set; }

        public string CANCELACCESSKEY { get; set; }

        public DateTime CANCELACCOUNTINGDATE { get; set; }

        public int CANCELACCOUNTINGDATETZID { get; set; }

        public string CANCELQRCODETEXT { get; set; }

        public string CANCELREASONCOMMENT { get; set; }

        public string CANCELTAXAUTHORITYINFO { get; set; }

        public decimal CANCELTOTALAMOUNT { get; set; }

        public long CHANNEL { get; set; }

        public int MESSAGESTATUS { get; set; }

        public string PROTOCOLNUMBER { get; set; }

        public int REPLICATIONCOUNTERFROMORIGIN { get; set; }

        public string RETURNCODEDESCRIPTION { get; set; }

        public string STORE { get; set; }

        public string TERMINAL { get; set; }

        public string TRANSACTIONID { get; set; }

        public string XMLREQUEST { get; set; }

        public string XMLRESPONSE { get; set; }

        public string DATAAREAID { get; set; }

        public DateTime ROWVERSION { get; set; }
    }
}
