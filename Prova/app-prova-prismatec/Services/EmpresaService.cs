using app_prova_prismatec.Domain.Models;
using app_prova_prismatec.Helpers;
using app_prova_prismatec.Services.Interfaces;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace app_prova_prismatec.Services
{
    public class EmpresaService : IEmpresaService
    {
        private Empresa empresa;
        public EmpresaService(Empresa _empresa)
        {
            this.empresa = _empresa;
        }

        public void CriarArquivo()
        {
            string path = Utils._recuperarDirectorioArquivo();
            Utils.CriarArquivo(this.empresa, path);

        }

        public void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone)
        {
            this.empresa.Alterar(cnpj, razaoSocial, nomeNomeFantasia, telefone);
        }
        public string VerificarDDD()
        {
            return this.empresa.VerificarCodigoDDD(ConfigurationSettings.AppSettings["DDD"].Split(',').Select(s => s.Trim()).ToList());
        }
    }
}
