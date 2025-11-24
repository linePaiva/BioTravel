namespace Biotravel.Modules.Employees
{
    public class EmployeeService
    {
        private List<Employee> _employees = new List<Employee>();

        public void AddEmployee(Employee employee)
        {
            _employees.Add(employee);
        }

        public List<Employee> GetAllEmployees()
        {
            return _employees;
        }
        public List<Employee> GetEmployees()
        {
            return _employees;
        }


        public void RemoveEmployee(int index)
        {
            if (index < 0 || index >= _employees.Count)
            {
                Console.WriteLine("Índice inválido! Tente novamente.");
                return;
            }

            _employees.RemoveAt(index);
            Console.WriteLine("Funcionário removido com sucesso!");
        }
        public void UpdateEmployee(int index, string newName, string newEmail, string newRole)
        {
            var employee = _employees[index];

            employee.Name = newName;
            employee.Email = newEmail;
            employee.Role = newRole;
        }


    }
}
