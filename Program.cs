using Biotravel.Modules.Employees;
using Biotravel.Modules.Clientes;
using Biotravel.Modules.Pacotes;
using Biotravel.Modules.Reservas;

var employeeService = new EmployeeService();
var employeeMenu = new EmployeeMenu(employeeService);

var clientesService = new ClientesService();
var clientesMenu = new ClientesMenu(clientesService);

var pacoteService = new PacoteService();
var pacoteMenu = new PacoteMenu(pacoteService);

var reservaService = new ReservaService();
var reservaMenu = new ReservaMenu(reservaService, pacoteService);

while (true)
{
    Console.WriteLine("\n===== MENU PRINCIPAL =====");
    Console.WriteLine("1 - Área de Funcionários");
    Console.WriteLine("2 - Área de Clientes");
    Console.WriteLine("3 - Área de Pacotes");
    Console.WriteLine("4 - Área de Reservas");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");

    string opc = Console.ReadLine()!;

    switch (opc)
    {
        case "1":
            employeeMenu.Show();
            break;

        case "2":
            clientesMenu.Show();
            break;

        case "3":
            pacoteMenu.Show();
            break;

        case "4":
            reservaMenu.Show();
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("Opção inválida!");
            break;
    }
}
