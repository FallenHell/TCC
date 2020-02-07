using GerenciaRHDao;
using GerenciaRHEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace GerenciaRHBusiness
{
    public class CepBusiness
    {
        public CEP ConsultarEndereco(string cep)
        {
            CEP OCep = new CEP();
            try
            {
                WebClient client = new WebClient();
                var result = client.DownloadString("http://viacep.com.br/ws/" + cep + "/json/");

                result = result.Replace("£", "").Replace("Ã", "ã");

                if (result.Contains("erro"))
                {
                    return OCep;
                }
                else
                {
                    OCep = JsonConvert.DeserializeObject<CEP>(result);
                }
            }

            catch (Exception ex)
            {

            }
            return OCep;
        }
    }
}
