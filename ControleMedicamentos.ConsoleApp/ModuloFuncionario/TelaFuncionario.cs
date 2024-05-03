using ControleMedicamentos.ConsoleApp.Compartilhado;

namespace ControleMedicamentos.ConsoleApp.ModuloFuncionario;
internal class TelaFuncionario : TelaBase
{
    public override void VisualizarRegistros(bool exibirTitulo)
    {
        if (exibirTitulo)
        {
            ApresentarCabecalho();

            Console.WriteLine("Visualizando Funcionários...");
        }

        Console.WriteLine();

        Console.WriteLine(
            "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
            "Id", "Nome", "Telefone", "Cpf"
        );

        EntidadeBase[] funcionariosCadastrados = repositorio.SelecionarTodos();

        foreach (Funcionario funcionarios in funcionariosCadastrados)
        {
            if (funcionarios == null)
                continue;

            Console.WriteLine(
                "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                funcionarios.Id, funcionarios.Nome, funcionarios.Telefone, funcionarios.Cpf
            );
        }

        Console.ReadLine();
        Console.WriteLine();
    }

    protected override EntidadeBase ObterRegistro()
    {
        Console.Write("Digite o nome do funcionario: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o telefone do funcionario: ");
        string telefone = Console.ReadLine();

        Console.Write("Digite cpf do funcionarios: ");
        string cpf = Console.ReadLine();

        Funcionario novoPaciente = new Funcionario(nome, telefone, cpf);

        return novoPaciente;
    }

    public void CadastrarEntidadeTeste()
    {
        Funcionario paciente = new Funcionario("Cleitinho Souza", "49 99999521", "123.456.789-10");

        repositorio.Cadastrar(paciente);
    }
}
