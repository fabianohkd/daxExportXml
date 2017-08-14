using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using DaxExportXML.Model;

namespace DaxExportXML.Repository
{
    /// <summary>
    /// Classe de acesso a dados vinculado ao modelo <see cref="EFDocumentXml_BR"/>
    /// </summary>
    public class EFDocumentXml_BRRepository
    {
        /// <summary>
        /// Conexão com o banco-de-dados
        /// </summary>
        public string ConnectionString = ConfigurationManager.ConnectionStrings["Choi"].ToString();

        /// <summary>
        /// Busca pela chave de acesso do documento
        /// </summary>
        /// <param name="accessKey">chave a ser consultada</param>
        /// <returns>uma lista de objetos</returns>
        public IList<EFDocumentXml_BR> GetByAccessKey(string accessKey)
        {
            //query com join
            var query = @" select * from FISCALDOCUMENT_BR F
                           join EFDOCUMENT_BR D 
                                on F.RECID = D.REFRECID
                           join EFDOCUMENTXML_BR X
                                on D.[RECID] = X.EFDOCREFRECID
                           where F.ACCESSKEY = @AccessKey; ";

            //conexão
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var xmls = sqlConnection.Query<FiscalDocument_BR, EFDocument_BR, EFDocumentXml_BR, EFDocumentXml_BR>(
                    query,
                    (fiscalDocument, efDocument, efDocumentXml) => {
                        efDocument.FiscalDocument_BR = fiscalDocument;
                        efDocumentXml.EFDocument_BR = efDocument;
                        return efDocumentXml;
                    },
                    new { AccessKey = accessKey },
                    splitOn: "REFRECID"
                );

                return xmls.ToList();
            }
        }

        /// <summary>
        /// Obter os registros pela empresa vinculada
        /// </summary>
        /// <param name="company"></param>
        /// <returns></returns>
        public IList<EFDocumentXml_BR> GetByDataAreaID(string company)
        {
            //query com join
            var query = @" select * from FISCALDOCUMENT_BR F
                           join EFDOCUMENT_BR D 
                                on F.RECID = D.REFRECID
                           join EFDOCUMENTXML_BR X
                                on D.[RECID] = X.EFDOCREFRECID
                           where X.DATAAREAID = @Company; ";

            //conexão
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var xmls = sqlConnection.Query<FiscalDocument_BR, EFDocument_BR, EFDocumentXml_BR, EFDocumentXml_BR>(
                    query,
                    (fiscalDocument, efDocument, efDocumentXml) => {
                        efDocument.FiscalDocument_BR = fiscalDocument;
                        efDocumentXml.EFDocument_BR = efDocument;
                        return efDocumentXml;
                    },
                    new { Company = company },
                    splitOn: "REFRECID"
                );

                return xmls.ToList();
            }
        }

        /// <summary>
        /// Obter uma lista pela empresa e o ano desejado
        /// </summary>
        /// <param name="company"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public IList<EFDocumentXml_BR> GetByDataAreaID(string company, int year)
        {
            //query com join
            var query = @" select * from FISCALDOCUMENT_BR F
                           join EFDOCUMENT_BR D 
                                on F.RECID = D.REFRECID
                           join EFDOCUMENTXML_BR X
                                on D.[RECID] = X.EFDOCREFRECID
                           where X.DATAAREAID = @Company
                                and  year(F.FISCALDOCUMENTDATE) = @Year ";

            //conexão
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var xmls = sqlConnection.Query<FiscalDocument_BR, EFDocument_BR, EFDocumentXml_BR, EFDocumentXml_BR>(
                    query,
                    (fiscalDocument, efDocument, efDocumentXml) => {
                        efDocument.FiscalDocument_BR = fiscalDocument;
                        efDocumentXml.EFDocument_BR = efDocument;
                        return efDocumentXml;
                    },
                    new { Company = company, Year = year },
                    splitOn: "REFRECID"
                );

                return xmls.ToList();
            }
        }

        /// <summary>
        /// Obter uma lista de registros por empresa no mês infomado
        /// </summary>
        /// <param name="company">nome da empresa</param>
        /// <param name="year">ano do registro</param>
        /// <param name="month">mês do registro</param>
        /// <returns></returns>
        public IList<EFDocumentXml_BR> GetByDataAreaID(string company, int year, int month)
        {
            //query com join
            var query = @" select * from FISCALDOCUMENT_BR F
                           join EFDOCUMENT_BR D 
                                on F.RECID = D.REFRECID
                           join EFDOCUMENTXML_BR X
                                on D.[RECID] = X.EFDOCREFRECID
                           where X.DATAAREAID = @Company
                                and year(F.FISCALDOCUMENTDATE) = @Year 
                                and month(F.FISCALDOCUMENTDATE) = @Month";

            //conexão
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var xmls = sqlConnection.Query<FiscalDocument_BR, EFDocument_BR, EFDocumentXml_BR, EFDocumentXml_BR>(
                    query,
                    (fiscalDocument, efDocument, efDocumentXml) => {
                        efDocument.FiscalDocument_BR = fiscalDocument;
                        efDocumentXml.EFDocument_BR = efDocument;
                        return efDocumentXml;
                    },
                    new { Company = company, Year = year, Month = month },
                    splitOn: "REFRECID"
                );

                return xmls.ToList();
            }
        }
    }
}
