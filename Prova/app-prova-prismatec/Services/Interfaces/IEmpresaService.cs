
namespace app_prova_prismatec.Services.Interfaces
{
    public interface IEmpresaService
    {
        void CriarArquivo();
        void Alterar(string cnpj, string razaoSocial, string nomeNomeFantasia, string telefone);
        string VerificarDDD();
    }
}
