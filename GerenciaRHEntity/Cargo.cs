using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace GerenciaRHEntity
{
    public class Cargo
    {
        public int IdCargo { get; set; }
        public string NomeCargo{ get; set; }
        List<Cargo> cargos { get; set; }
        public ETipoCargo TipoCargo { get; set; }
    }
}
