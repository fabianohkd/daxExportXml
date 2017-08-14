using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxExportXML.Model
{
    public class EFDocumentXml_BR
    {
        public long EFDOCREFRECID { get; set; }

        public string SUBMISSION { get; set; }

        public string CANCEL { get; set; }

        public string CANCELRESPONSE { get; set; }

        public string SUBMISSIONRESPONSE { get; set; }

        public string SUBMITRETURN { get; set; }

        public string SUBMITRETURNRESPONSE { get; set; }

        public string DATAAREAID { get; set; }

        public int RECVERSION { get; set; }

        public long PARTITION { get; set; }

        public long RECID { get; set; }

        public EFDocument_BR EFDocument_BR { get; set; }
    }
}
