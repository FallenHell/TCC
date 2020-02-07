using GerenciaRHDao;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace GerenciaRHBusiness
{
    public class AvaliacaoBusiness
    {
        private readonly AvaliacaoDao Dao = new AvaliacaoDao();
        public List<Avaliacao> ListarAvaliacoes(int idGestor)
        {
            try
            {
                List<Avaliacao> avaliacoes = Dao.ListarAvaliacoes(idGestor);
                return avaliacoes;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool InserirAvaliacao(Avaliacao avaliacao)
        {
            try
            {
                bool verificacao = Dao.AlterarAvaliacao(avaliacao);
                avaliacao.Nota = CalcularNota(avaliacao);

                avaliacao.DtAvaliacao = DateTime.Now;
                bool inserido = Dao.InserirAvaliacao(avaliacao);
                return inserido;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

       
        //teste

        public string CalcularNota(Avaliacao avaliacao)
        {
            int notaFinal = 0;
            double media = 0;
            int teste;
            string nota = string.Empty;
            try
            {
                int notaCliente = (int)avaliacao.NotaClientes;
                int notaDesenv = (int)avaliacao.NotaDesenv;
                int notaDeveres = (int)avaliacao.NotaDeveres;
                int notaEquipe = (int)avaliacao.NotaEquipe;

                media = Convert.ToDouble((notaCliente + notaDesenv + notaDeveres + notaEquipe)) / 4;
                var truncado = Math.Round(media + 1,2);

                if (truncado > 3)
                {
                    nota = "A";
                }
                else if(truncado > 2 && truncado <= 3)
                {
                    nota = "B";
                }
                else
                {
                    nota = "C";
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return nota;
        }
    }
}
