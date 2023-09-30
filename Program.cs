using DelegateApp;

internal class Program
{
    private static void Main(string[] args)
    {
        var emps = new Employee[]
        {
        new Employee { Name = "Yahia", ID = 1, Department = "CS", Salary = 20000 },
        new Employee { Name = "Ali", ID = 2, Department = "HR", Salary = 15000 },
        new Employee { Name = "Mohamed", ID = 3, Department = "IT", Salary = 12000 },
        new Employee { Name = "Ammar", ID = 4, Department = "IS", Salary = 11000 },
        new Employee { Name = "Abdo", ID = 5, Department = "PR", Salary = 9000 },
        new Employee { Name = "Ziad", ID = 6, Department = "IT", Salary = 7500 },
        new Employee { Name = "Tarek", ID = 7, Department = "CS", Salary = 5000 },
        new Employee { Name = "Ahmed", ID = 8, Department = "SEO", Salary = 4500 },
        new Employee { Name = "Khaled", ID = 9, Department = "IT", Salary = 4000 },
        };

        Report report = new Report();
        report.empReport(emps, "All Employees", emp => true);
        report.empReport(emps, "IT Employees", emp => emp.Department == "IT");
        report.empReport(emps, "CS Employees", emp => emp.Department == "CS");
        report.empReport(emps, "HR Employees", emp => emp.Department == "HR");
        report.empReport(emps, "IS Employees", emp => emp.Department == "IS");
        report.empReport(emps, "PR Employees", emp => emp.Department == "PR");
        report.empReport(emps, "SEO Employees", emp => emp.Department == "SEO");

        report.empReport(emps, "Employees with Salary > 10000", emp => emp.Salary > 10000);
        report.empReport(emps, "Employees with Salary < 10000", emp => emp.Salary < 10000);
        report.empReport(emps, "Employees with Salary > 15000", emp => emp.Salary > 15000);
        report.empReport(emps, "Employees with Salary < 15000", emp => emp.Salary < 15000);
        report.empReport(emps, "Employees with Salary > 20000", emp => emp.Salary > 20000);
        report.empReport(emps, "Employees with Salary < 20000 and > 10000", emp => emp.Salary < 20000 && emp.Salary > 10000);

        report.SalaryChanged += Report_SalaryChanged;//subscribe to the event
        Console.WriteLine("Report of salary change ");
        Console.WriteLine("==================================");
        report.ChangeSalaryBy(0.6m, emps[0]);//raise the event
        report.ChangeSalaryBy(0.5m, emps[1]);
        report.ChangeSalaryBy(0.4m, emps[2]);

        report.ChangeSalaryBy(0.3m, emps[3]);
        report.ChangeSalaryBy(0.2m, emps[4]);
        report.ChangeSalaryBy(0.1m, emps[5]);

        report.ChangeSalaryBy(0.0m, emps[6]);
        report.ChangeSalaryBy(0.1m, emps[7]);
        report.ChangeSalaryBy(-0.2m, emps[8]);//raise the event
                                              // report.SalaryChanged -= Report_SalaryChanged;//unsubscribe from the event
        Console.WriteLine(  "The new report after the new salary change");
        Console.WriteLine( "====================================");
        report.empReport(emps, "All Employees", emp => true);
        report.empReport(emps, "IT Employees", emp => emp.Department == "IT");
        report.empReport(emps, "CS Employees", emp => emp.Department == "CS");
        report.empReport(emps, "HR Employees", emp => emp.Department == "HR");
        report.empReport(emps, "IS Employees", emp => emp.Department == "IS");
        report.empReport(emps, "PR Employees", emp => emp.Department == "PR");
        report.empReport(emps, "SEO Employees", emp => emp.Department == "SEO");

        report.empReport(emps, "Employees with Salary > 10000", emp => emp.Salary > 10000);
        report.empReport(emps, "Employees with Salary < 10000", emp => emp.Salary < 10000);
        report.empReport(emps, "Employees with Salary > 15000", emp => emp.Salary > 15000);
        report.empReport(emps, "Employees with Salary < 15000", emp => emp.Salary < 15000);
        report.empReport(emps, "Employees with Salary > 20000", emp => emp.Salary > 20000);
        report.empReport(emps, "Employees with Salary < 20000 and > 10000", emp => emp.Salary < 20000 && emp.Salary > 10000);





        for (; ; ) { 
        Console.ReadKey();
    }   
}

    private static void Report_SalaryChanged(Employee employee, decimal oldSalary)
    {
        if (employee.Salary > oldSalary)
        {
            Console.ForegroundColor = ConsoleColor.Green;
        }
        else if (employee.Salary < oldSalary)
        {
            Console.ForegroundColor = ConsoleColor.Red;//
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Gray;//default color
        }
        Console.WriteLine($"Salary of {employee.Name} has changed from {oldSalary} to {employee.Salary}");
        Console.WriteLine("\n \n");
        Console.ForegroundColor = ConsoleColor.Gray;//default color
    }
}