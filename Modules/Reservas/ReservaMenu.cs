using Biotravel.Modules.Pacotes;

namespace Biotravel.Modules.Reservas
{
    public class ReservaMenu
    {
        private readonly ReservaService _service;
        private readonly PacoteService _pacoteService;

        public ReservaMenu(ReservaService service, PacoteService pacoteService)
        {
            _service = service;
            _pacoteService = pacoteService;
        }

        public void FazerReserva()
        {
            var pacotes = _pacoteService.ListarPacotes();

            if (pacotes.Count == 0)
            {
                Console.WriteLine("Nenhum pacote cadastrado para reservar.");
                return;
            }

            Console.Write("Nome do cliente: ");
            string cliente = Console.ReadLine();

            Console.WriteLine("\nEscolha o número do pacote:");
            for (int i = 0; i < pacotes.Count; i++)
                Console.WriteLine($"{i + 1} - {pacotes[i].Nome} ({pacotes[i].Destino}) - R${pacotes[i].Preco}");

            int.TryParse(Console.ReadLine(), out int escolha);

            if (escolha < 1 || escolha > pacotes.Count)
            {
                Console.WriteLine("Pacote inválido!");
            }
            else
            {
                _service.FazerReserva(cliente, pacotes[escolha - 1]);
                Console.WriteLine("Reserva realizada com sucesso!");
            }
        }

        public void VerReservas()
        {
            var reservas = _service.ListarReservas();

            if (reservas.Count == 0)
            {
                Console.WriteLine("Nenhuma reserva encontrada.");
                return;
            }

            foreach (var r in reservas)
            {
                Console.WriteLine($"\nCliente: {r.Cliente}, Pacote: {r.PacoteEscolhido.Nome}, Destino: {r.PacoteEscolhido.Destino}, Preço: R${r.PacoteEscolhido.Preco}");
            }
        }

        public void Show()
        {
            while (true)
            {
                Console.WriteLine("\n=== MENU DE RESERVAS ===");
                Console.WriteLine("1 - Fazer Reserva");
                Console.WriteLine("2 - Ver Reservas");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                string opc = Console.ReadLine()!;

                switch (opc)
                {
                    case "1":
                        FazerReserva();
                        break;

                    case "2":
                        VerReservas();
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
