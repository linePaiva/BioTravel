using System;

namespace Biotravel.Modules.Employees
{
    public class EmployeeMenu
    {
        private readonly EmployeeService _service;

        public EmployeeMenu(EmployeeService service)
        {
            _service = service;
        }

        public void Show()
        {
            int option = -1;

            while (option != 0)
            {
                Console.WriteLine("\n=== Módulo de Funcionários ===");
                Console.WriteLine("1 - Cadastrar funcionário");
                Console.WriteLine("2 - Listar funcionários");
                Console.WriteLine("3 - Editar funcionário");
                Console.WriteLine("4 - Excluir funcionário");
                Console.WriteLine("0 - Voltar");
                Console.Write("Escolha uma opção: ");

                int.TryParse(Console.ReadLine(), out option);

                switch (option)
                {
                    case 1:
                        RegisterEmployee();
                        break;
                    case 2:
                        ListEmployees();
                        break;
                    case 3:
                        EditEmployeeOption();
                        break;
                    case 4:
                        RemoveEmployeeOption();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
            }
        }

        private void RegisterEmployee()
        {
            Console.Write("\nNome completo: ");
            string name = Console.ReadLine() ?? "";

            Console.Write("E-mail corporativo: ");
            string email = Console.ReadLine() ?? "";

            Console.Write("Cargo/Função: ");
            string role = Console.ReadLine() ?? "";

            var newEmployee = new Employee
            {
                Name = name,
                Email = email,
                Role = role,
            };

            _service.AddEmployee(newEmployee);

            Console.WriteLine("Funcionário cadastrado com sucesso!");
        }

        private void ListEmployees()
        {
            var employees = _service.GetAllEmployees();

            Console.WriteLine("\n=== Funcionários Cadastrados ===");

            if (employees.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            foreach (var emp in employees)
            {
                Console.WriteLine($"• {emp.Name} | {emp.Email} | {emp.Role}");
            }
        }
                    private void RemoveEmployeeOption()
        {
            Console.Clear();
            Console.WriteLine("=== Excluir Funcionário ===");

            var employees = _service.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            // Lista funcionários com índice
            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine($"{i} - {employees[i].Name} ({employees[i].Role})");
            }

            Console.Write("\nDigite o número do funcionário que deseja excluir: ");
            int index = int.Parse(Console.ReadLine()!);

            _service.RemoveEmployee(index);
        }
        private void EditEmployeeOption()
        {
            Console.Clear();
            Console.WriteLine("=== Editar Funcionário ===");

            var employees = _service.GetEmployees();

            if (employees.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            // listar funcionários de forma completa
            for (int i = 0; i < employees.Count; i++)
            {
                var emp = employees[i];
                Console.WriteLine($"{i} - {emp.Name} ({emp.Email}, {emp.Role})");
            }

            Console.Write("\nDigite o número do funcionário que deseja editar: ");

            if (!int.TryParse(Console.ReadLine(), out int index) || index < 0 || index >= employees.Count)
            {
                Console.WriteLine("Índice inválido!");
                return;
            }

            var employee = employees[index];

            Console.Write($"Novo nome completo (ENTER para manter: {employee.Name}): ");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                employee.Name = newName;

            Console.Write($"Novo e-mail corporativo (ENTER para manter: {employee.Email}): ");
            string? newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail))
                employee.Email = newEmail;

            Console.Write($"Novo cargo/função (ENTER para manter: {employee.Role}): ");
            string? newRole = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newRole))
                employee.Role = newRole;

            _service.UpdateEmployee(index, employee.Name, employee.Email, employee.Role);

            Console.WriteLine("\nFuncionário atualizado com sucesso!");
        }


    }
}

