using Biotravel.Modules.Pacotes;

namespace Biotravel.Modules.Reservas
{
    public class ReservaService
    {
        private readonly List<Reserva> _reservas = new List<Reserva>();

        public void FazerReserva(string cliente, Pacote pacote)
        {
            _reservas.Add(new Reserva
            {
                Cliente = cliente,
                PacoteEscolhido = pacote
            });
        }

        public List<Reserva> ListarReservas()
        {
            return _reservas;
        }
    }
}
