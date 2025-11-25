using System;

namespace Biotravel.Modules.Clientes
{
    public class ClientesMenu
    {
        private readonly ClientesService _service;

        public ClientesMenu(ClientesService service)
        {
            _service = service;
        }

        public void Show()
        {
            Console.WriteLine("Cadastro de Clientes:");

            while (true)
            {
                _service.CadastrarCliente();

                Console.WriteLine("\nDeseja salvar os dados de mais um cliente? [S] Sim [N] Não");
                string continuar = Console.ReadLine().ToLower();

                if (continuar != "s")
                    break;
            }

            var lista = _service.ListarClientes();

            Console.WriteLine($"\nTotal de Clientes Salvos: {lista.Count}");

            Console.WriteLine("\nDeseja listar os clientes salvos? [S] Sim [N] Não");
            string listar = Console.ReadLine().ToLower();

            if (listar == "s")
            {
                foreach (var c in lista)
                {
                    Console.WriteLine($"\nNome.........: {c.Nome}");
                    Console.WriteLine($"CPF..........: {c.CpfID}");
                    Console.WriteLine($"Gênero.......: {c.Genero}");
                    Console.WriteLine($"Telefone.....: {c.Telefone}");
                    Console.WriteLine($"E-mail.......: {c.Email}");
                    Console.WriteLine($"Nacionalidade: {c.Nacionalidade}");
                    Console.WriteLine($"Origem.......: {c.Origem}");
                    Console.WriteLine($"Status.......: {c.Status}");
                    Console.WriteLine($"Observações..: {c.Observacoes}");
                    Console.WriteLine($"Preferências.: {c.Preferencias}");
                }
            }

            Console.WriteLine("O Programa se encerrará ao pressionar uma tecla.");
            Console.ReadKey();
        }
    }
}
