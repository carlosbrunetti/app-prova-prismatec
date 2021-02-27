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

        public Empresa(Guid id, string cnpj, string razaoSocial, string nomeFantasia, string telefone
            , IEnumerable<Funcionario> funcionarios)
        {
            this.Id = id;
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;
            this.Telefone = telefone;
            this.Funcionarios = funcionarios;
        }   

        public void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeNomeFantasia;
            this.Telefone = telefone;
        }

        public string VerificarCodigoDDD(List<string> ddd)
        {
            var localidadeDDD = this.Telefone.Substring(0, 2);
            if (ddd.Contains(localidadeDDD))
                return $"O DDD '{localidadeDDD}' pertence ao RS.";

            return $"O DDD '{localidadeDDD}' não pertence ao RS.";
        }

    }
}