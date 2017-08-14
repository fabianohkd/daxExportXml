using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DaxExportXML.Business
{
    /// <summary>
    /// Responsavel por centralizar as regras de negócio do modelo <see cref="Model.EFDocumentXml_BR"/>
    /// </summary>
    public class EFDocumentXml_BRBusiness
    {

        public void gerarXmlNaPasta(String path, Model.EFDocumentXml_BR xml, bool subPasta)
        {
            //se o diretório existir
            if (Directory.Exists(path))
            {
                //se a subpasta for selecionada
                if (subPasta)
                    Directory.CreateDirectory(path += $"\\{xml.DATAAREAID.ToUpper()}\\{xml.EFDocument_BR.FiscalDocument_BR.FISCALDOCUMENTDATE.Year.ToString("0000")}\\{xml.EFDocument_BR.FiscalDocument_BR.FISCALDOCUMENTDATE.Month.ToString("00")}\\{xml.EFDocument_BR.FiscalDocument_BR.FISCALDOCUMENTDATE.Day.ToString("00")}");

                if (xml.SUBMISSION != null) {
                    //determinar o padrão do arquivo a ser exportado
                    var aprovada = $"{path}\\{xml.EFDocument_BR.FiscalDocument_BR.FISCALDOCUMENTDATE.ToString("yyyy-MM-dd")}_{xml.DATAAREAID}_{xml.EFDocument_BR.FiscalDocument_BR.ACCESSKEY}.xml";

                    //se o arquivo não existir
                    if (!File.Exists(aprovada))
                    {
                        //criando o arquivo
                        File.Create(aprovada).Dispose();
                        using (TextWriter tw = new StreamWriter(aprovada))
                        {
                            //escrevendo o arquivo
                            tw.WriteLine(XDocument.Parse(xml.SUBMISSION).ToString());
                            tw.Close();
                        }
                    }
                }

                //se a nota for cancelada no sitema
                if (xml.CANCEL != null)
                {
                    //determinar o padrão do arquivo a ser exportado CANCEL
                    var cancelada = $"{path}\\{xml.EFDocument_BR.FiscalDocument_BR.FISCALDOCUMENTDATE.ToString("yyyy-MM-dd")}_{xml.DATAAREAID}_{xml.EFDocument_BR.FiscalDocument_BR.ACCESSKEY}_cancelada.xml";

                    //se o arquivo não existir
                    if (!File.Exists(cancelada))
                    {
                        //criando o arquivo
                        File.Create(cancelada).Dispose();
                        using (TextWriter tw = new StreamWriter(cancelada))
                        {
                            //escrevendo o arquivo
                            tw.WriteLine(XDocument.Parse(xml.CANCEL).ToString());
                            tw.Close();
                        }
                    }
                }
            }
            else
                throw new DirectoryNotFoundException($"O diretório não existe: {path}");
        }

    }
}
