using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DaxExportXML.Business
{
    public class RetailFiscalDocument_BRBusiness
    {

        public void gerarXmlNaPasta(String path, Model.RetailFiscalDocument_BR xml, bool subPasta)
        {
            //se o diretório existir
            if (Directory.Exists(path))
            {
                //se a subpasta for selecionada
                if (subPasta)
                    Directory.CreateDirectory(path += $"\\{xml.FISCALDOCUMENTDATETIME.Year.ToString("0000")}\\{xml.FISCALDOCUMENTDATETIME.Month.ToString("00")}\\{xml.FISCALDOCUMENTDATETIME.Day.ToString("00")}");
                
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

    }
}
