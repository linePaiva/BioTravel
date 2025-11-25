namespace Biotravel.Modules.Pacotes
{
    public class PacoteService
    {
        public List<Pacote> Pacotes { get; } = new List<Pacote>();

        public void CadastrarPacote(Pacote p)
        {
            Pacotes.Add(p);
        }

        public List<Pacote> ListarPacotes()
        {
            return Pacotes;
        }
    }
}
