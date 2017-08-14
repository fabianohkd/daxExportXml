using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxExportXML.Model
{
    public class EFDocument_BR
    {
        public string CONTINGENCYREASON { get; set; }

        public int CONTINGENCYMODE { get; set; }

        public string PROTOCOLNUMBER { get; set; }

        public string RETURNMESSAGE { get; set; }

        public int AVERAGERESPONSETIME { get; set; }

        public long REFRECID { get; set; }

        public int MESSAGETYPE { get; set; }

        public int MESSAGESTATUS { get; set; }

        public long RETURNCODEREFRECID { get; set; }

        public DateTime DATE { get; set; }

        public int TIME { get; set; }

        public string RETURNCODEDESCRIPTION { get; set; }

        public string RECEIPTNUMBER { get; set; }

        public long CONTINGENCYMODEREFRECID { get; set; }

        public string CONSUMEREFDOCINQUIRYURL { get; set; }

        public DateTime CONTINGENCYDATETIME { get; set; }

        public int CONTINGENCYDATETIMETZID { get; set; }

        public long CONTINGENCYDATETIMEOFFSET { get; set; }

        public string QRCODETEXT { get; set; }

        public string DATAAREAID { get; set; }

        public int RECVERSION { get; set; }

        public long PARTITION { get; set; }

        public long RECID { get; set; }

        public string CANCELQRCODETEXT { get; set; }

        public FiscalDocument_BR FiscalDocument_BR { get; set; }

        private IList<EFDocumentXml_BR> efDocumentXmls;
        public IList<EFDocumentXml_BR> EFDocumentXmls
        {
            get
            {
                if (efDocumentXmls == null)
                    efDocumentXmls = new List<EFDocumentXml_BR>();
                return efDocumentXmls;
            }
            set { efDocumentXmls = value; }
        }
    }
}
