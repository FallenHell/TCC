using GerenciaRHDao;
using GerenciaRHEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHBusiness
{
    public class CargoBusiness
    {
        CargoDao Dao = new CargoDao();
        public List<Cargo> ListarCargos (Cargo cargo)
        {
            List<Cargo> cargos = Dao.ListarCargos(cargo);
            return cargos;
        }
    }
}
