using Biotravel.Modules.Pacotes;

namespace Biotravel.Modules.Pacotes
{
    public class PacoteMenu
    {
        private readonly PacoteService _service;

        public PacoteMenu(PacoteService service)
        {
            _service = service;
        }

        public void CadastrarPacote()
        {
            Pacote p = new Pacote();

            Console.Write("Nome do pacote: ");
            p.Nome = Console.ReadLine();

            Console.Write("Destino: ");
            p.Destino = Console.ReadLine();

            Console.Write("Preço: ");
            double.TryParse(Console.ReadLine(), out double preco);
            p.Preco = preco;

            _service.CadastrarPacote(p);

            Console.WriteLine("Pacote cadastrado com sucesso!");
        }

        public void VerPacotes()
        {
            var pacotes = _service.ListarPacotes();

            if (pacotes.Count == 0)
            {
                Console.WriteLine("Nenhum pacote cadastrado.");
                return;
            }

            int id = 1;
            foreach (var p in pacotes)
            {
                Console.WriteLine($"\nPacote {id}: Nome: {p.Nome}, Destino: {p.Destino}, Preço: R${p.Preco}");
                id++;
            }
        }
        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU DE PACOTES ===");
                Console.WriteLine("1 - Cadastrar Pacote");
                Console.WriteLine("2 - Ver Pacotes");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                string opc = Console.ReadLine()!;

                switch (opc)
                {
                    case "1":
                        CadastrarPacote();
                        break;

                    case "2":
                        VerPacotes();
                        break;

                    case "0":
                        return;

                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

    }
}
