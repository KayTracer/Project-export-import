// See https://aka.ms/new-console-template for more information
using Projeto02.Entities;
using Projeto02.Repositories;
using Projeto02.Utils;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\n**** EXPORTADOR DE FUNCIONÁRIOS **** ");

        try
        {
            var funcionario = new Funcionario();
            funcionario.Setor = new Setor();
            funcionario.Funcao = new Funcao();

            funcionario.Id = Guid.NewGuid();
            funcionario.Nome = ConsoleUtil.ReadString("Nome do funcionário: ");
            funcionario.Cpf = ConsoleUtil.ReadString("CPF: ");
            funcionario.Matricula = ConsoleUtil.ReadString("Matrícula: ");
            funcionario.Salario = ConsoleUtil.ReadDecimal("Salário: ");
            funcionario.DataAdmissao = ConsoleUtil.ReadDateTime("Data de admissão: ");

            funcionario.Setor.Id = Guid.NewGuid();
            funcionario.Setor.Nome = ConsoleUtil.ReadString("Nome do setor: ");
            funcionario.Setor.Sigla = ConsoleUtil.ReadString("Sigla: ");

            funcionario.Funcao.Id = Guid.NewGuid();
            funcionario.Funcao.Descricao = ConsoleUtil.ReadString("Descrição da função: ");

            var funcionarioRepository = new FuncionarioRepository();
            funcionarioRepository.Exportar(funcionario);

            Console.WriteLine("\nFuncionário gravado em JSON com sucesso!");

            //Importando o funcionário
            var registro = funcionarioRepository.Importar();
            Console.WriteLine("Id do Funcionário..: "+ registro.Id);
            Console.WriteLine("Nome..: " + registro.Nome);
            Console.WriteLine("CPF..: " + registro.Cpf);
            Console.WriteLine("Matrícula..: "+ registro.Matricula);
            Console.WriteLine("Salário..: "+registro.Salario);
            Console.WriteLine("Data de admissão..: "+registro.DataAdmissao);

            Console.WriteLine("Id do setor..: " + registro.Setor.Id);
            Console.WriteLine("Sigla..:" + registro.Setor.Sigla);
            Console.WriteLine("Nome do setor..: "+ registro.Setor.Nome);

            Console.WriteLine("Id da Função..: " + registro.Funcao.Id);
            Console.WriteLine("Descrição..: " + registro.Funcao.Descricao);

        }

        catch (Exception e)
        {
            Console.WriteLine("\nErro: " + e.Message);
        }

        Console.ReadKey();
    }
}