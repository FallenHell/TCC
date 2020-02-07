using GerenciaRHEntity;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciaRHDao
{
    public class CargoDao : ConexaoBase

    {

        public List<Cargo> ListarCargos(Cargo cargo)
        {
            List<Cargo> listacargo = new List<Cargo>();
            
            using(var conexaoBD = this.Conexao())
            {
                string sql = "select  NomeCargo from Cargo Where (@IdCargo is null or @IdCargo = 0) or(IdCargo = @IdCargo) and(@NomeCargo is null) or(NomeCargo = @NomeCargo)";
                listacargo = conexaoBD.Query<Cargo>(sql, cargo).ToList();
            }
            return listacargo;
        }

    }
}
