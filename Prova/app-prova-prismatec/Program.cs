using app_prova_prismatec.Helpers;
using app_prova_prismatec.Domain.Models;
using app_prova_prismatec.Services;
using Serilog;
using System;
using System.Collections.Generic;

namespace app_prova_prismatec
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.CriarLogger();
            Logger.ImprimirLog("Iniciando...");

            var empresa = popularEmpresa();
            var empresaService = new EmpresaService(empresa);
            Logger.ImprimirLog("Criando e populando a entidade empresa e funcionario.");


            Logger.ImprimirLog("Gerando arquivo...");
            empresaService.CriarArquivo();
            Logger.ImprimirLog("Arquivo gerado.");

            Logger.ImprimirLog("Alterando os valores das entidades...");
            empresaService.Alterar("84166365099999", "Cláudio e Heitor Ltda", "Supermercado Dois Irmãos", "5128904886");
            alterarFuncionario(empresa);
            Logger.ImprimirLog("Valores alterados.");

            Logger.ImprimirLog("Gerando o novo arquivo com as alterações feitas nas entidades...");
            empresaService.CriarArquivo();
            Logger.ImprimirLog("Arquivo gerado com as alterações dos valores das entidades.");
            
            Logger.ImprimirLog("Verificando se a localidade do telefone infomado pertence ao RS...");
            Logger.ImprimirLog(empresaService.VerificarDDD());

            Logger.ImprimirLog("Finalizado...");
            Console.ReadKey();

            //TODO: Conforme a abordagem Domain Driven Design, crie uma instância e utilize a entidade "Empresa" e "Funcionario", populando suas propriedades.

            //TODO: Salve o objeto criado em formato .json em um arquivo local (pasta configurada no app settings).

            //TODO: Altere os dados das propriedades e salve novamente o arquivo (o mesmo não pode ser sobrescrito).

            //TODO: Crie um método que verifica se no telefone da empresa, se o código da região é do RS (Utilize LINQ).

            //TODO: Imprima no console logs dos eventos de todas as ações realizadas no sistema.

        }

        #region Metodos
        //Método que cria e popula o funcionario
        private static IList<Funcionario> popularFuncionario(Guid empresa)
        {
            return new List<Funcionario>()
            {
                new Funcionario(Guid.NewGuid(), "88752910040", "Carlos Santos", empresa)
            };
        }

        //Método que altera o funcionário
        private static void alterarFuncionario(Empresa empresa)
        {
            foreach (var item in empresa.Funcionarios)
            {
                item.Alterar("42536741595", "João da Silva", empresa.Id);
            }
        }

        //Método que cria e popula a empresa vinculando o funcionário a empresa
        private static Empresa popularEmpresa()
        {
            var idEmpresa = Guid.NewGuid();
            var funcionarios = popularFuncionario(idEmpresa);
            var empresa = new Empresa(idEmpresa, "84166365000180", "Cláudio e Heitor Alimentos Ltda", "Supermercado Passarinho", "1128904886", funcionarios);
            return empresa;
        }
        #endregion
    }
}
