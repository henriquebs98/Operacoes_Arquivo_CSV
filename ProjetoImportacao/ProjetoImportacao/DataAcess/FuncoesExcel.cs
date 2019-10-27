using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoImportacao.DataAcess
{
     static class FuncoesExcel
    {
        public static void CarregaExcelOperacoes(ref List<Operacoes> ListaOperacoes)
        {
            using (var leitorOperacoes = new StreamReader(ConfigurationManager.AppSettings["ArquivoOperacoes"].ToString()))
            {
                string linha = string.Empty;

                while (leitorOperacoes.ReadLine() != null)
                {
                    linha = leitorOperacoes.ReadLine();

                    string[] objOperacao = linha.Split(';');

                    var Operacao = new Operacoes();
                    Operacao.CodigoOperacao = Convert.ToInt32(objOperacao[0]);
                    Operacao.DataInicio = Convert.ToDateTime(objOperacao[1]);
                    Operacao.DataFim = Convert.ToDateTime(objOperacao[2]);
                    Operacao.NomeSubProduto = objOperacao[9];
                    Operacao.Quantidade = Convert.ToDouble(objOperacao[12]);
                    Operacao.CodigoPreco = Convert.ToInt32(objOperacao[13]);

                    ListaOperacoes.Add(Operacao);
                }
            }
        }

        public static void CarregaExcelDadosMercado(ref List<Mercado> ListaMercado)
        {

            using (var leitorMercado = new StreamReader(ConfigurationManager.AppSettings["ArquivoDadosMercado"].ToString()))
            {
                string linhaMercado = string.Empty;

                while (leitorMercado.ReadLine() != null)
                {
                    linhaMercado = leitorMercado.ReadLine();

                    string[] objMercado = linhaMercado.Split(';');

                    var Mercado = new Mercado();

                    Mercado.IDPreco = Convert.ToInt32(objMercado[0]);
                    Mercado.NumeroPrazoDiasCorridos = Convert.ToInt32(objMercado[1]);
                    Mercado.ValorPreco = Convert.ToDouble(objMercado[2]);

                    ListaMercado.Add(Mercado);
                }
            }

        }

        public static void ExportaRelatorio(ref List<Relatorio> ListaRelatorio)
      {

          var sw = new StreamWriter(ConfigurationManager.AppSettings["CaminhoArquivoFinal"].ToString(), false);  
          var sb = new StringBuilder();

          var linhaDados = "SUBGRUPO;RESULTADO";
          sw.WriteLine(linhaDados);   

          foreach (var R in ListaRelatorio)
          {
              linhaDados = string.Format("{0};{1}",
                                  R.SubGrupo,
                                  R.Resultado
                              );

              sw.WriteLine(linhaDados);

          }

          //linhaDados = string.Format("Tempo total de execucao em Segundos: {0}", Convert.ToDecimal(stopWath.Elapsed.TotalSeconds.ToString()));
          //sw.WriteLine(linhaDados);
          //linhaDados = string.Format("Tempo total de execucao em Minutos:  {0}", Convert.ToDecimal(stopWath.Elapsed.TotalMinutes.ToString()));
          //sw.WriteLine(linhaDados);


          sw.Close();
      }
              
     }
}
