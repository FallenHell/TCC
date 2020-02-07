using GerenciaRHDao;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHBusiness
{
    public class ImpedimentoBusiness
    {
        private readonly ImpedimentoDao Dao = new ImpedimentoDao();
        public List<Impedimento> listarImpedimentos(Impedimento impedimento)
        {
            List<Impedimento> impedimentos = Dao.ListarImpedimentos(impedimento);
            return impedimentos.Count > 0 ? impedimentos : new List<Impedimento>();
        }

        public bool InserirImpedimento (Impedimento impedimento)
        {
            bool inserido = Dao.InserirImpedimento(impedimento);
            return inserido;
        }

        public bool UpdateImpedimento (Impedimento impedimento)
        {
            bool alterado = Dao.AlterarImpedimento(impedimento);
            return alterado;
        }
    }
}
