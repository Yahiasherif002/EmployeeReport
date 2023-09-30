using System;


namespace DelegateApp
{ 
    public delegate bool DepartmentFilter(Employee emp);

    public delegate void OnSalaryChangeHandler(Employee employee, decimal oldSalary);
    public class Report
    {
       public event OnSalaryChangeHandler SalaryChanged;
         
        public void empReport(Employee[] emps,string title, DepartmentFilter departmentFilter) {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(title);
            Console.WriteLine("=====================================");
            Console.ForegroundColor = ConsoleColor.Blue;
            foreach (var emp in emps)

            {
                if(departmentFilter(emp))
                   
                Console.WriteLine($"{emp.Name} - {emp.Department} - {emp.Salary}");
            }
            Console.WriteLine("\n \n");

        }

        public void ChangeSalaryBy(decimal percentage, Employee employee)
        {
            var oldSalary = employee.Salary;
            employee.Salary +=Math.Round( employee.Salary * percentage,2);
            SalaryChanged?.Invoke(employee, oldSalary);
        }
    }
}
