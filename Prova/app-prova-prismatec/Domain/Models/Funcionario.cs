using app_prova_prismatec.Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace app_prova_prismatec.Domain.Models
{
    public class Funcionario : IFuncionario
    {
        public Guid Id { get; private set; }

        public string Cpf { get; private set; }

        public string Nome { get; private set; }

        public Guid IdEmpresa { get; private set; }

        #region Construtor
        public Funcionario(Guid id, string cpf, string nome, Guid idEmpresa)
        {
            this.Id = id;
            this.Cpf = cpf;
            this.Nome = nome;
            this.IdEmpresa = idEmpresa;
        }
        #endregion

        #region Métodos
        //Altera os atributos do funcionário
        public void Alterar(string cpf, string nome, Guid idEmpresa)
        {
            this.Cpf = cpf;
            this.Nome = nome;
            this.IdEmpresa = idEmpresa;
        }
        #endregion
    }
}
