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
    public class FiscalDocument_BRRepository
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
        public List<FiscalDocument_BR> GetByAccessKey(string accessKey)
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
                var documents = sqlConnection.Query<FiscalDocument_BR, EFDocument_BR, EFDocumentXml_BR, FiscalDocument_BR>(
                    query,
                    (fiscalDocument, efDocument, efDocumentXml) => {
                        efDocument.EFDocumentXmls.Add(efDocumentXml);
                        fiscalDocument.EFDocuments.Add(efDocument);
                        return fiscalDocument;
                    },
                    new { AccessKey = accessKey },
                    splitOn: "REFRECID"
                );

                return documents.ToList();
            }
        }


    }
}
