using System;
using System.Collections.Generic;

namespace Biotravel.Modules.Clientes
{
    public class ClientesService
    {
        private List<Clientes> _clientes = new List<Clientes>();
        private int _contador = 1;

        public void CadastrarCliente()
        {
            var x = new Clientes();

            Console.WriteLine("\nInsira os Dados Pedidos a Seguir:");

            x.Nome = $"[{_contador}] " + Ler("Nome do Cliente");
            x.CpfID = $"[{_contador}] " + Ler("CPF ou ID");
            x.Nacionalidade = $"[{_contador}] " + Ler("Nacionalidade");
            x.Genero = $"[{_contador}] " + Ler("Gênero");
            x.Telefone = $"[{_contador}] " + Ler("Telefone");
            x.Email = $"[{_contador}] " + Ler("E-mail");
            x.Preferencias = $"[{_contador}] " + Ler("Preferências");
            x.Origem = $"[{_contador}] " + Ler("Contato de Origem");
            x.Observacoes = $"[{_contador}] " + Ler("Observações");
            x.Status = $"[{_contador}] " + Ler("Status");

            _clientes.Add(x);
            _contador++;

            Console.WriteLine("\nCliente Salvo Com Sucesso!");
        }

        public List<Clientes> ListarClientes()
        {
            return _clientes;
        }

        private string Ler(string campo)
        {
            Console.Write($"{campo}........:");
            return Console.ReadLine();
        }
    }
}
