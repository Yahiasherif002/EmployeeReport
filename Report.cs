using System;


namespace DelegateApp
{
    public class Report
    {
        public delegate bool DepartmentFilter(Employee emp);
        public void empReport(Employee[] emps,string title, DepartmentFilter departmentFilter) { 
            Console.WriteLine(title);
            Console.WriteLine("=====================================");
            foreach (var emp in emps)
            {
                if(departmentFilter(emp))
                Console.WriteLine($"{emp.Name} - {emp.Department} - {emp.Salary}");
            }
            Console.WriteLine("\n \n");
        }
    }
}
