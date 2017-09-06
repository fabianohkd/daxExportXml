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
        /// <summary>
        /// Construtor padrão da classe
        /// </summary>
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo acionado ao clicar no botão selecionar
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">events <see cref="EventArgs"/> </param>
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

        /// <summary>
        /// Metodo acioando ao clicar em executar
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">events <see cref="EventArgs"/></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            //zerar barra de progresso
            toolStripProgressBar.Value = 0;

            //obter o periodo selecionado do componente datePicker
            var year = dateTimePicker1.Value.Year;
            var month = dateTimePicker1.Value.Month;
            var day = dateTimePicker1.Value.Day;

            var empresa = cbEmpresa.SelectedItem.ToString();

            if (cbTipo.SelectedIndex==0)
            {
                await gerarXmlRetail(empresa, year, month);
                //exibir msg para o usuario
                MessageBox.Show("Processo concluido, todas os XML foram exportados na pasta.");
            }
            else
            {
                await gerarXmlAx(empresa, year, month);
                //exibir msg para o usuario
                MessageBox.Show("Processo concluido, todas os XML foram exportados na pasta.");
            }

        }

        /// <summary>
        /// Exporta os arquivos xml do retail com base nos parametros
        /// </summary>
        /// <param name="empresa">empresa a qual se pretende obter os dados</param>
        /// <param name="year">ano de referencia</param>
        /// <param name="month">mês de referencia</param>
        /// <returns></returns>
        private async Task gerarXmlRetail(string empresa, int year, int month)
        {
            var proc = new RetailFiscalDocument_BRBusiness();
            var result = proc.GetByCompany(empresa, year, month);

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
        }

        /// <summary>
        /// Exporta os arquivos xml do dynamics ax
        /// </summary>
        /// <param name="empresa">nome da empresa</param>
        /// <param name="year">ano de referencia</param>
        /// <param name="month">mês de referencia</param>
        /// <returns></returns>
        internal async Task gerarXmlAx(string empresa, int year, int month)
        {
            var dao = new EFDocumentXml_BRRepository();
            var proc = new EFDocumentXml_BRBusiness();
            var result = dao.GetByDataAreaID(empresa, year, month);

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
        }

    }
}
