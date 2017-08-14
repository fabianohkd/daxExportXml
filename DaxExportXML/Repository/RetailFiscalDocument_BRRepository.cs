using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
using DaxExportXML.Model;

namespace DaxExportXML.Repository
{
    /// <summary>
    /// 
    /// </summary>
    public class RetailFiscalDocument_BRRepository
    {
        /// <summary>
        /// Conexão com o banco-de-dados
        /// </summary>
        public string ConnectionString = ConfigurationManager.ConnectionStrings["RetailVRD"].ToString();

        /// <summary>
        /// Retorna uma lista de documentos da empresa selecionada
        /// </summary>
        /// <param name="company">codigo da empresa</param>
        /// <returns></returns>
        public List<RetailFiscalDocument_BR> GetAllByCompany(string company)
        {
            var list = new List<RetailFiscalDocument_BR>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                list = sqlConnection.Query<RetailFiscalDocument_BR>("select * from RetailFiscalDocument_BR where DataAreaID = @Company ", new { Company = company }).ToList<RetailFiscalDocument_BR>();
            }

            return list;
        }

        /// <summary>
        /// Obter todos os registros
        /// </summary>
        /// <returns>uma lista de documentos</returns>
        public List<RetailFiscalDocument_BR> GetAll()
        {
            var list = new List<RetailFiscalDocument_BR>();

            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var result = sqlConnection.Query<RetailFiscalDocument_BR>("select * from RetailFiscalDocument_BR");

                foreach (RetailFiscalDocument_BR product in result)
                    list.Add(product);
            }

            return list;
        }

        /// <summary>
        /// Obter um registro pela chave de acesso
        /// </summary>
        /// <param name="AccessKey">Chave de acesso</param>
        /// <returns></returns>
        public RetailFiscalDocument_BR GetById(string AccessKey)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.Query<RetailFiscalDocument_BR>("select * from RetailFiscalDocument_BR where AccessKey = @AccessKey ", new { Id = AccessKey }).SingleOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inicio"></param>
        /// <param name="fim"></param>
        /// <param name="company"></param>
        /// <returns></returns>
        public List<RetailFiscalDocument_BR> GetByDate(DateTime inicio, DateTime fim, Company company)
        {
            return null;
        }
    }

    public enum Company
    {
        DRJ,
        LOG,
        RDC
    }
}
