using System;
using GerenciaRHBusiness;
using GerenciaRHEntity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GerenciaRHTest.UnitTestBusiness
{
    [TestClass]
    public class UnitTestCep
    {
        [TestMethod]
        public void ConsultarEndereco()
        {
            CepBusiness cepBusiness = new CepBusiness();
            CEP cep = new CEP();
            string stringCEP = "05412004";
            cep = cepBusiness.ConsultarEndereco(stringCEP);
            Assert.IsNotNull(cep);
        }
    }
}
