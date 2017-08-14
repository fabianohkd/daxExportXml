using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaxExportXML.Model
{
    public class FiscalDocument_BR
    {
        public string ACCESSKEY { get; set; }

        public DateTime ACCOUNTINGDATE { get; set; }

        public string AUDITEDBY { get; set; }

        public DateTime AUDITEDDATETIME { get; set; }

        public int AUDITEDDATETIMETZID { get; set; }

        public DateTime CANCELACCOUNTINGDATE { get; set; }

        public string CANCELINVENTORYVOUCHERID { get; set; }

        public string CANCELREASONCOMMENT { get; set; }

        public string CANCELVOUCHERID { get; set; }

        public string CFPSID { get; set; }

        public long CITYWHERESERVICEPERFORMED { get; set; }

        public int COMPLEMENTARYTYPE { get; set; }

        public long COMPLEMENTEDFISCALDOCUMENT { get; set; }

        public int CORRECTIONLETTER { get; set; }

        public string DELIVERYCNPJCPF { get; set; }

        public string DELIVERYIE { get; set; }

        public long DELIVERYLOGISTICSPOSTALADDRESS { get; set; }

        public string DELIVERYMODE { get; set; }

        public string DELIVERYTERM { get; set; }

        public int DIRECTION { get; set; }

        public string FISCALDOCUMENTACCOUNTNUM { get; set; }

        public int FISCALDOCUMENTACCOUNTTYPE { get; set; }

        public DateTime FISCALDOCUMENTDATE { get; set; }

        public long FISCALDOCUMENTFORMAT { get; set; }

        public int FISCALDOCUMENTISSUER { get; set; }

        public string FISCALDOCUMENTNUMBER { get; set; }

        public string FISCALDOCUMENTSERIES { get; set; }

        public string FISCALESTABLISHMENT { get; set; }

        public string FISCALESTABLISHMENTCCMNUM { get; set; }

        public string FISCALESTABLISHMENTCNPJCPF { get; set; }

        public string FISCALESTABLISHMENTIE { get; set; }

        public string FISCALESTABLISHMENTNAME { get; set; }

        public string FISCALESTABLISHMENTPHONE { get; set; }

        public long FISCALESTABLISHMENTPOSTALADDRESS { get; set; }

        public string FISCALESTABLISHMENTTRIBSUBSTITUTIONREG { get; set; }

        public int FREIGHTCHARGETERMS { get; set; }

        public long IMPORTDECLARATION { get; set; }

        public string INVENTORYVOUCHER { get; set; }

        public string MODEL { get; set; }

        public int NUMERICCODE { get; set; }

        public string OPERATIONDESCRIPTION { get; set; }

        public string PACKINGBRAND { get; set; }

        public int PREVIOUSVERSION { get; set; }

        public int PURPOSE { get; set; }

        public long REFRECID { get; set; }

        public int REFTABLEID { get; set; }

        public long SALESCARRIER { get; set; }

        public long SALESCARRIERLOGISTICSPOSTALADDRESS { get; set; }

        public int SPECIE { get; set; }

        public int STATUS { get; set; }

        public string THIRDPARTYCCMNUM { get; set; }

        public string THIRDPARTYCNPJCPF { get; set; }

        public string THIRDPARTYFAX { get; set; }

        public string THIRDPARTYIE { get; set; }

        public string THIRDPARTYNAME { get; set; }

        public string THIRDPARTYPHONE { get; set; }

        public long THIRDPARTYPOSTALADDRESS { get; set; }

        public decimal TOTALAMOUNT { get; set; }

        public decimal TOTALDISCOUNTAMOUNT { get; set; }

        public decimal TOTALGOODSAMOUNT { get; set; }

        public decimal TOTALMARKUPFREIGHTAMOUNT { get; set; }

        public decimal TOTALMARKUPINSURANCEAMOUNT { get; set; }

        public decimal TOTALMARKUPOTHERAMOUNT { get; set; }

        public decimal TOTALSERVICESAMOUNT { get; set; }

        public int TYPEOFCTE { get; set; }

        public string VEHICLELICENSEPLATENUMBER { get; set; }

        public string VEHICLELICENSEPLATESTATE { get; set; }

        public int VERSION { get; set; }

        public string VOUCHER { get; set; }

        public int FINALUSER { get; set; }

        public DateTime FISCALDOCUMENTDATETIME { get; set; }

        public int FISCALDOCUMENTDATETIMETZID { get; set; }

        public long FISCALDOCUMENTDATETIMEOFFSET { get; set; }

        public int PRESENCETYPE { get; set; }

        public string THIRDPARTYEMAIL { get; set; }

        public string THIRDPARTYFOREIGNERID { get; set; }

        public int THIRDPARTYICMSCONTRIBUTOR { get; set; }

        public decimal TOTALSUFRAMADISCOUNTCOFINSAMOUNT { get; set; }

        public decimal TOTALSUFRAMADISCOUNTICMSAMOUNT { get; set; }

        public decimal TOTALSUFRAMADISCOUNTPISAMOUNT { get; set; }

        public DateTime MODIFIEDDATETIME { get; set; }

        public string MODIFIEDBY { get; set; }

        public DateTime CREATEDDATETIME { get; set; }

        public string CREATEDBY { get; set; }

        public string DATAAREAID { get; set; }

        public int RECVERSION { get; set; }

        public long PARTITION { get; set; }

        public long RECID { get; set; }

        public string CANCELACCESSKEY { get; set; }

        public string CANCELTAXAUTHORITYINFO { get; set; }

        public decimal CHANGEAMOUNT { get; set; }

        public string FISCALESTABLISHMENTTRADENAME { get; set; }

        public decimal ORIGINALDISCOUNTAMOUNT { get; set; }

        public string TAXAUTHORITYINFO { get; set; }

        private IList<EFDocument_BR> efDocuments;
        public IList<EFDocument_BR> EFDocuments
        {
            get
            {
                if (efDocuments == null) efDocuments = new List<EFDocument_BR>();
                return efDocuments;
            }
            set { efDocuments = value; }
        }
    }
}
