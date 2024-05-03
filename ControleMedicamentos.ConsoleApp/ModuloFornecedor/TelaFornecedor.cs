using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMedicamentos.ConsoleApp.ModuloFornecedor
{

    using global::ControleMedicamentos.ConsoleApp.Compartilhado;
    using global::ControleMedicamentos.ConsoleApp.ModuloPaciente;

    namespace ControleMedicamentos.ConsoleApp.ModuloPaciente
    {
        internal class TelaFornecedor : TelaBase
        {
            public EntidadeBase novoFornecedor { get; private set; }
            public IEnumerable<Fornecedor> fornecedoresCadastrados { get; private set; }

            public override void VisualizarRegistros(bool exibirTitulo)
            {
                if (exibirTitulo)
                {
                    ApresentarCabecalho();

                    Console.WriteLine("Visualizando Fornecedores...");
                }

                Console.WriteLine();

                Console.WriteLine(
                    "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                    "CNPJ", "Nome", "Telefone"
                );

                EntidadeBase[] pacientesCadastrados = repositorio.SelecionarTodos();

                foreach (Fornecedor fornecedor in fornecedoresCadastrados)
                {
                    if (fornecedor == null)
                        continue;

                    Console.WriteLine(
                        "{0, -10} | {1, -15} | {2, -15} | {3, -15}",
                        fornecedor.CNPJ, fornecedor.Nome, fornecedor.Telefone
                    );
                }

                Console.ReadLine();
                Console.WriteLine();
            }

            protected override EntidadeBase ObterRegistro()
            {
                Console.Write("Digite o nome do fornecedor: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o telefone do fornecedor: ");
                string telefone = Console.ReadLine();

                Console.Write("Digite o cartão do CNPJ do fornecedor: ");
                string cnpj = Console.ReadLine();

                Fornecedor fornecedor = new Fornecedor(nome, telefone, cnpj);

                return fornecedor;
            }

            public void CadastrarEntidadeTeste()
            {
                Fornecedor fornecedor = new Fornecedor("Bobby Tables", "49 9999-9521", "12.123.123/0001-12");

                repositorio.Cadastrar(fornecedor);
            }
        }
    }
}
