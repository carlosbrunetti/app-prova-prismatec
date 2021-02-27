﻿using app_prova_prismatec.Helpers;
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
            _Logger.CriarLogger();
            _Logger.ImprimirLog("Iniciando...");
            
            var empresa = _popularEmpresa("84166365000180", "Cláudio e Heitor Alimentos Ltda", "Supermercado Passarinho", "1128904886");

            _Logger.ImprimirLog("Criando e populando a entidade empresa e funcionario.");
            var empresaService = new EmpresaService(empresa);

            _Logger.ImprimirLog("Gerando arquivo...");
            empresaService.CriarArquivo();
            _Logger.ImprimirLog("Arquivo gerado.");

            _Logger.ImprimirLog("Alterando os valores das entidades...");            
            empresaService.Alterar("84166365099999", "Cláudio e Heitor Ltda", "Supermercado Dois Irmãos", "5128904886");
            _Logger.ImprimirLog("Valores alterados.");

            _Logger.ImprimirLog("Gerando o novo arquivo com as alterações feitas nas entidades...");
            empresaService.CriarArquivo();
            _Logger.ImprimirLog("Arquivo gerado com as alterações dos valores das entidades.");

            _Logger.ImprimirLog("Verificando se a localidade do telefone infomado pertence ao RS...");
            _Logger.ImprimirLog(empresaService.VerificarDDD());
            //TODO: Conforme a abordagem Domain Driven Design, crie uma instância e utilize a entidade "Empresa" e "Funcionario", populando suas propriedades.

            //TODO: Salve o objeto criado em formato .json em um arquivo local (pasta configurada no app settings).

            //TODO: Altere os dados das propriedades e salve novamente o arquivo (o mesmo não pode ser sobrescrito).

            //TODO: Crie um método que verifica se no telefone da empresa, se o código da região é do RS (Utilize LINQ).

            //TODO: Imprima no console logs dos eventos de todas as ações realizadas no sistema.
            _Logger.ImprimirLog("Finalizado...");
            Console.ReadKey();
        }

        private static IList<Funcionario> _popularFuncionario(Guid empresa)
        {
            return new List<Funcionario>()
            {
                new Funcionario(Guid.NewGuid(), "88752910040", "Carlos Santos", empresa),
                new Funcionario(Guid.NewGuid(), "88752915987", "Rodrigo Silva", empresa)
            };
        }


        private static Empresa _popularEmpresa(string cnpj,string razaoSocial, string nomeFantasia, string telefone)
        {
            var idEmpresa = Guid.NewGuid();
            var funcionarios = _popularFuncionario(idEmpresa);
            return new Empresa(idEmpresa, cnpj, razaoSocial, nomeFantasia, telefone, funcionarios);
        }
    }
}