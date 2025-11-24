using Biotravel.Modules.Employees;

var employeeService = new EmployeeService();
var employeeMenu = new EmployeeMenu(employeeService);

employeeMenu.Show();
