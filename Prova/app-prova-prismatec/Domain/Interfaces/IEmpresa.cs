using app_prova_prismatec.Domain.Models;
using System;
using System.Collections.Generic;

namespace app_prova_prismatec.Domain.Interfaces
{
    public interface IEmpresa
    {
        Guid Id { get;}

        string Cnpj { get;}

        string RazaoSocial { get;}

        string NomeFantasia { get;}

        string Telefone { get;}

        IEnumerable<IFuncionario> Funcionarios { get;}
        void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone);
        string VerificarCodigoDDD(List<string> ddd);
    }
}
