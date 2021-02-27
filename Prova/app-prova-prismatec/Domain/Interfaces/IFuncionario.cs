using System;


namespace app_prova_prismatec.Domain.Interfaces
{
    public interface IFuncionario
    {
        Guid Id { get;}

        string Cpf { get; }

        string Nome { get; }

        Guid IdEmpresa { get; }

        void Alterar(string cpf, string nome, Guid idEmpresa);
    }
}
