using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetoImportacao.DataAcess
{
    static class Calculo
    {
        public static void ResultadoOperacao(ref List<Operacoes> ListaOperacoes, ref List<Mercado> ListaMercado, ref List<Relatorio> ListaRelatorio)
        {
            foreach (var itemOperacao in ListaOperacoes)
            {
                TimeSpan date = Convert.ToDateTime(itemOperacao.DataFim) - Convert.ToDateTime(itemOperacao.DataInicio);

                int totalDias = date.Days;

                var ListaMercadoFiltrada = (from o in ListaMercado
                                            where o.IDPreco == itemOperacao.CodigoPreco &
                                                    o.NumeroPrazoDiasCorridos == totalDias
                                            select o).FirstOrDefault();

                if (!(ListaMercadoFiltrada == null))
                {
                    itemOperacao.Resultado = ListaMercadoFiltrada.ValorPreco * itemOperacao.Quantidade;
                }
                else
                {
                    itemOperacao.Resultado = 0;
                }

              
            }

            //monta os subgrupos
            ListaRelatorio = (from o in ListaOperacoes

                              group o by o.NomeSubProduto into g

                              select new Relatorio

                              {
                                  SubGrupo = g.Key,

                                  Resultado = g.Sum(o => o.Resultado).ToString()

                              }).ToList();
        
        }

    }
}
