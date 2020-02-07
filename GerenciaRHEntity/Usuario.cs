using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Enums;

namespace GerenciaRHEntity
{
    public class Usuario
    {
        [Required]
        public int IdUsuario { get; set; }
        public int? IdGestor { get; set; }
        public int? IdUsuarioAlteracao { get; set; }
        public int IdCargo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "- É necessário inserir o nome...")]
        public string NomeUsuario { get; set; }
        [Required(ErrorMessage = "- É necessário inserir a senha...")]
        public string Senha { get; set; }
        public string Racf { get; set; }

        [Display(Name = "CPF/CNPJ")]
        [Required(ErrorMessage = "- É necessário inserir o CPF/CNPJ...")]

        public string CPFCNPJ { get; set; }
        public string CEP { get; set; }
        public string PIS { get; set; }
        [Display(Name = "Tipo do Documento")]
        [Required(ErrorMessage = "- É necessário selecionar o tipo de documento...")]

        public ETipoDocumento TipoDocumento { get; set; }
        public string Motivo { get; set; }
        [Display(Name = "Número do Endereço")]
        [Required(ErrorMessage = "- É necessário inserir o número do logradouro...")]

        public int NumeroEndereco { get; set; }
        [Display(Name = "Endereço")]
        [Required(ErrorMessage = "- É necessário inserir o endereço...")]

        public string Endereco { get; set; }
        public string Nota { get; set; }
        public long Salario { get; set; }
        public string Email { get; set; }
        public DateTime? DtAdmissao { get; set; }
        public DateTime? DtDemissao { get; set; }
        public bool Ativo { get; set; }
        List<Usuario> ListaUsuario { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "- É necessário selecionar o cargo...")]

        public string NomeCargo { get; set; }
        public int IdDesligamento { get; set; }
  


    }
}
