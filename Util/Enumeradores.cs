using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class Enumeradores
    {
        enum TipoLog
        {
            Exclusao = 1,
            Inclusao = 2,
            Atualizacao = 3
        }

        enum TipoChat
        {
            Duvida = 1,
            Reclamacao = 2,
            Avaliacao = 3
        }

        enum TipoCargo
        {
            Gestor = 1,
            Gerente = 2,
            GerenteRH = 3,
            FuncionarioRH = 4,
            Funcionario = 5,

        }
    }
}
