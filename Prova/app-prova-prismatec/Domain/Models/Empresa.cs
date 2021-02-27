using app_prova_prismatec.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_prova_prismatec.Domain.Models
{
    public class Empresa
    {
        public Guid Id { get; private set; }

        public string Cnpj { get; private set; }

        public string RazaoSocial { get; private set; }

        public string NomeFantasia { get; private set; }

        public string Telefone { get; private set; }
        public IEnumerable<Funcionario> Funcionarios { get; private set; }

        #region Construtor
        public Empresa(Guid id, string cnpj, string razaoSocial, string nomeFantasia, string telefone, IEnumerable<Funcionario> funcionarios)
        {
            this.Id = id;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;
            this.Telefone = telefone;
            this.Funcionarios = funcionarios;
        }
        #endregion

        #region Métodos
        //Altera os atributos da empresa
        public void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeNomeFantasia;
            this.Telefone = telefone;            
        }

        //Método que verifica se o DDD é do RS
        public bool VerificarCodigoDDD(List<string> ddd)
        {
            return ddd.Contains(this.Telefone.Substring(0, 2));         
        }
        #endregion
    }
}