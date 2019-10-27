using ProjetoImportacao.DataAcess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoImportacao
{
    public partial class FormResultado : Form
    {

        public FormResultado()
        {
            InitializeComponent();
        }

        #region | Variaveis / Objetos Globais
        string Explorer = null;
        string caminhoArquivoFinal = null;
        Stopwatch stopWath = new Stopwatch();
        List<Operacoes> ListaOperacoes = new List<Operacoes>();
        List<Mercado> ListaMercado = new List<Mercado>();
        List<Relatorio> ListaRelatorio = new List<Relatorio>();
        #endregion

        #region | Eventos

        // Eventos Utilizados para minimizar o formulário e definir ele na bandeja do Windows

        private void FormResultado_Resize(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Minimized;
            ShowIcon = false;
            notifyIcon.Visible = true;
            this.Hide();

        }

        private void FormResultado_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            ShowIcon = false;
            notifyIcon.Visible = true;
            this.Hide();
            notifyIcon.ShowBalloonTip(3000, "ExportResults aberto", "clique com botão direito no icone na bandeja para iniciar a execução", ToolTipIcon.None);
        }

        // Evento do menu que é aberto ao clicar com botão direito do mouse sobre o icone

        private void iniciarExecuçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            #region | Troca Icone
            Thread trocaIcone = new Thread(TrocaIcone);
            trocaIcone.Start();
            #endregion

            stopWath.Start();

            notifyIcon.ShowBalloonTip(3000, "Execução Iniciada...", "avisaremos quando a execução for finalizada...", ToolTipIcon.Info);

            ExecutaRobo();

            stopWath.Stop();

            var tempo = stopWath.Elapsed.Minutes;

            MessageBox.Show("Tempo de execução total: " + tempo.ToString());

            Explorer = ConfigurationManager.AppSettings["LocalAbertura"].ToString();
            caminhoArquivoFinal = ConfigurationManager.AppSettings["DiretorioFinal"].ToString();

            notifyIcon.ShowBalloonTip(3000, "Execução finalizada com sucesso!", "Arquivo excel salvo no diretório padrão clique aqui para acessar...", ToolTipIcon.Info);         
            notifyIcon.Icon = new Icon("imagens/tool.ico");
            
        }

        private void pararExecuçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(Explorer) & string.IsNullOrEmpty(caminhoArquivoFinal)))
            {
                Process.Start(Explorer, caminhoArquivoFinal);
            }
        }

        #endregion

        #region | Métodos

        private void ExecutaRobo()
        {

            FuncoesExcel.CarregaExcelOperacoes(ref ListaOperacoes);

            FuncoesExcel.CarregaExcelDadosMercado(ref ListaMercado);

            Calculo.ResultadoOperacao(ref ListaOperacoes, ref ListaMercado, ref ListaRelatorio);

            FuncoesExcel.ExportaRelatorio(ref ListaRelatorio);

        }

        private void TrocaIcone()
        {
           notifyIcon.Icon = new Icon("imagens/favicon.ico");
        }

        #endregion

    }

}
