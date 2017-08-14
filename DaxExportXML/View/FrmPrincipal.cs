using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using DaxExportXML.Business;
using DaxExportXML.Repository;

namespace DaxExportXML
{
    public partial class FrmPrincipal : Form
    {

        public FrmPrincipal()
        {
            InitializeComponent();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //abre o formulario de pasta
            var result = folderBrowserDialog1.ShowDialog();

            //se o usuario selecionar um local
            if (result.Equals(DialogResult.OK))
            {
                tbPath.Text = folderBrowserDialog1.SelectedPath;
                btExportar.Enabled = true;
            }
        }


        private async void button1_Click(object sender, EventArgs e)
        {
            ////zerar barra de progresso
            //toolStripProgressBar.Value = 0;

            //var dao = new RetailFiscalDocument_BRRepository();
            //var result = dao.GetAllByCompany("drj");
            //var proc = new RetailFiscalDocument_BRBusiness();

            //foreach (var item in result)
            //{
            //    //ajusta a barra de progresso
            //    toolStripProgressBar.Maximum = result.Count;
            //    toolStripProgressBar.Increment(1);

            //    await Task.Run(() => {
            //        //gravando arquivo na pasta
            //        proc.gerarXmlNaPasta(tbPath.Text, item, cbSubPasta.Checked);
            //    });
            //}

            ////exibir msg para o usuario
            //MessageBox.Show("Processo concluido, todas os XML foram exportados na pasta.");


            //zerar barra de progresso
            toolStripProgressBar.Value = 0;

            var dao = new EFDocumentXml_BRRepository();
            var result = dao.GetByDataAreaID("rdc", 2017, 7);
            var proc = new EFDocumentXml_BRBusiness();

            foreach (var item in result)
            {
                //ajusta a barra de progresso
                toolStripProgressBar.Maximum = result.Count;
                toolStripProgressBar.Increment(1);

                await Task.Run(() => {
                    //gravando arquivo na pasta
                    proc.gerarXmlNaPasta(tbPath.Text, item, cbSubPasta.Checked);
                });
            }

            //exibir msg para o usuario
            MessageBox.Show("Processo concluido, todas os XML foram exportados na pasta.");

        }



    }
}
