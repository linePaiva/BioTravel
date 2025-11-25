using Biotravel.Modules.Pacotes;

namespace Biotravel.Modules.Reservas
{
    public class Reserva
    {
        public string? Cliente { get; set; }
        public Pacote? PacoteEscolhido { get; set; }
    }
}
