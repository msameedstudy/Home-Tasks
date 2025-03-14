using System;

public class Employee
{
    
    public int EmployeeID { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public double Salary { get; set; }
    public string Department { get; set; }

   
    public Employee(int employeeID, string fname, string lname, DateTime dob, double salary, string department)
    {
        EmployeeID = employeeID;
        FirstName = fname;
        LastName = lname;
        DateOfBirth = dob;
        Salary = salary;
        Department = department;
    }
}

public class Company
{
    public string CompanyName { get; set; }
    private Employee[] employees;  
    private int employeeCount; 

    // Constructor
    public Company(string cname, int count)
    {
        CompanyName = cname;
        employees = new Employee[count]; 
        employeeCount = 0; 
    }

   
    public void AddEmployee(Employee employee)
    {
        if (employeeCount < employees.Length)
        {
            employees[employeeCount] = employee;
            employeeCount++; // Increment the count of employees
            Console.WriteLine($"Employee {employee.FirstName} {employee.LastName} added to the company.");
        }
        else
        {
            Console.WriteLine("Muft ka paisa nahi ha bhai... No more space to add. Array is full.");
        }
    }

    public void RemoveEmployee(int employeeID)
    {
        bool found = false;


        for (int i = 0; i < employeeCount; i++)
        {
            if (employees[i].EmployeeID == employeeID)
            {
                found = true;
                
                for (int j = i; j < employeeCount - 1; j++)
                {
                    employees[j] = employees[j + 1];
                }
                
                employees[employeeCount - 1] = null;
                employeeCount--; 
                Console.WriteLine($"Employee with ID {employeeID} removed from the company.");
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee not found.");
        }
    }


    public void displayemp(int employeeID)
    {
        bool found = false;

        
        for (int i = 0; i < employeeCount; i++)
        {
            if (employees[i].EmployeeID == employeeID)
            {
                found = true;
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("Employee Details:");
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine($"ID: {employees[i].EmployeeID}");
                Console.WriteLine($"Name: {employees[i].FirstName} {employees[i].LastName}");
                Console.WriteLine($"Date of Birth: {employees[i].DateOfBirth.ToShortDateString()}");
                Console.WriteLine($"Salary: PKR{employees[i].Salary}");
                Console.WriteLine($"Department: {employees[i].Department}");
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Employee not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Company company = new Company("Intech.", 3);

        Employee emp1 = new Employee(101, "Habib", "Shan", new DateTime(1990, 5, 1), 65000, "Coder");
        Employee emp2 = new Employee(102, "Chand", "Roshan", new DateTime(1985, 8, 12), 75000, "Marketing");
        Employee emp3 = new Employee(103, "Jan", "dil", new DateTime(1992, 11, 24), 60000, "HR");

        company.AddEmployee(emp1);
        company.AddEmployee(emp2);
        company.AddEmployee(emp3);
        Console.WriteLine("----------------------------------------------------------------");

company.displayemp(101);

       
        company.RemoveEmployee(102);


        company.displayemp(102);

   
        company.displayemp(101);
        company.displayemp(103);
    }
}
