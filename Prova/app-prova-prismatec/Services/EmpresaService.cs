using app_prova_prismatec.Domain.Models;
using app_prova_prismatec.Helpers;
using app_prova_prismatec.Services.Interfaces;
using System.Configuration;
using System.Linq;

namespace app_prova_prismatec.Services
{
    public class EmpresaService : IEmpresaService
    {
        private Empresa empresa;

        #region Construtor
        public EmpresaService(Empresa _empresa)
        {
            empresa = _empresa;
        }
        #endregion

        #region Métodos
        //Método que cria um arquivo no formato passado
        public void CriarArquivo()
        {
            string path = Utils.RecuperarDirectorioArquivo();
            Utils.CriarArquivoJson(empresa, path);

        }

        //Método  que altera os os atributos da empresa
        public void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone)
        {
            empresa.Alterar(cnpj, razaoSocial, nomeNomeFantasia, telefone);
        }

        //Método responsavel por verificar se o DDD passado pertence ao RS
        public string VerificarDDD()
        {
            if (empresa.VerificarCodigoDDD(ConfigurationSettings.AppSettings["DDD"].Split(',').Select(s => s.Trim()).ToList()))
                return $"O DDD '{empresa.Telefone.Substring(0, 2)}' pertence ao RS.";
            return $"O DDD '{empresa.Telefone.Substring(0, 2)}' não pertence ao RS.";
        }
        #endregion
    }
}
