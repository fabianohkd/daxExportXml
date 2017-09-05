using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DaxExportXML.Model;
using DaxExportXML.Repository;

namespace DaxExportXML.Business
{
    /// <summary>
    /// Classe responsável por centralizar as regras do negocio do model <see cref="RetailFiscalDocument_BR"/>
    /// </summary>
    public class RetailFiscalDocument_BRBusiness
    {
        /// <summary>
        /// Exporta o xml correspondente ao registro na pasta informada
        /// </summary>
        /// <param name="path">caminho para exportar o arquivo</param>
        /// <param name="xml">objeto <see cref="Model.RetailFiscalDocument_BR"/></param>
        /// <param name="subPasta">cria subpastas com as datas</param>
        public void gerarXmlNaPasta(String path, RetailFiscalDocument_BR xml, bool subPasta)
        {
            //se o diretório existir
            if (Directory.Exists(path))
            {
                //se a subpasta for selecionada
                if (subPasta)
                    Directory.CreateDirectory(path += $"\\{xml.DATAAREAID.ToUpper()}\\{xml.FISCALDOCUMENTDATETIME.Year.ToString("0000")}\\{xml.FISCALDOCUMENTDATETIME.Month.ToString("00")}\\{xml.FISCALDOCUMENTDATETIME.Day.ToString("00")}");
                
                //determinar o padrão do arquivo a ser exportado
                var filename = $"{path}\\{xml.FISCALDOCUMENTDATETIME.ToString("yyyy-MM-dd")}_{xml.DATAAREAID}_{xml.ACCESSKEY}.xml";

                //se o arquivo não existir
                if (!File.Exists(filename))
                {
                    //criando o arquivo
                    File.Create(filename).Dispose();
                    using (TextWriter tw = new StreamWriter(filename))
                    {
                        //escrevendo o arquivo
                        tw.WriteLine(XDocument.Parse(xml.XMLREQUEST).ToString());
                        tw.Close();
                    }
                }
            }
            else
                throw new DirectoryNotFoundException($"O diretório não existe: {path}");
        }

        /// <summary>
        /// Retorna uma lista de documentos da empresa selecionada
        /// </summary>
        /// <param name="company">codigo da empresa</param>
        /// <returns>Lista de <seealso cref="RetailFiscalDocument_BR"/> </returns>
        public List<RetailFiscalDocument_BR> GetByCompany(string company)
        {
            return new RetailFiscalDocument_BRRepository().GetByCompany(company);
        }

    }
}
