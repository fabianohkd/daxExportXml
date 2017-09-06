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
    /// Classe responsável por centralizar o acesso a dados do tipo <see cref="RetailFiscalDocument_BR"/>
    /// </summary>
    public class RetailFiscalDocument_BRRepository
    {
        #region Fields
        /// <summary>
        /// Conexão com o banco-de-dados
        /// </summary>
        private string ConnectionString = ConfigurationManager.ConnectionStrings["RetailVRD"].ToString();
        #endregion

        #region Methods
        /// <summary>
        /// Retorna uma lista de documentos da empresa selecionada
        /// </summary>
        /// <param name="company">codigo da empresa</param>
        /// <param name="year">ano do registro</param>
        /// <param name="month">mês do registro</param>
        /// <returns></returns>
        internal List<RetailFiscalDocument_BR> GetByCompany(string company, int year, int month)
        {
            //query
            var query = @"select * from RetailFiscalDocument_BR 
                          where DataAreaID = @Company 
                                and year(FISCALDOCUMENTDATETIME) = @Year 
                                and month(FISCALDOCUMENTDATETIME) = @Month ";

            //conexão
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                var list = sqlConnection.Query<RetailFiscalDocument_BR>(
                    query,
                    new {
                        Company = company,
                        Year = year,
                        Month = month
                    }
                    ).ToList<RetailFiscalDocument_BR>();

                return list;
            }

        }

        /// <summary>
        /// Obter todos os registros
        /// </summary>
        /// <returns>uma lista de documentos</returns>
        internal List<RetailFiscalDocument_BR> GetAll()
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
        internal RetailFiscalDocument_BR GetById(string AccessKey)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                return sqlConnection.Query<RetailFiscalDocument_BR>("select * from RetailFiscalDocument_BR where AccessKey = @AccessKey ", new { Id = AccessKey }).SingleOrDefault();
            }
        }

        /// <summary>
        /// Obter registros em um periodo selecionado
        /// </summary>
        /// <param name="inicio">data inicial</param>
        /// <param name="fim">data final</param>
        /// <param name="company">empresa</param>
        /// <returns>lista de documentos do tipo <seealso cref="RetailFiscalDocument_BR"/> </returns>
        internal List<RetailFiscalDocument_BR> GetByDate(DateTime inicio, DateTime fim, Company company)
        {
            return null;
        }
        #endregion
    }

}
