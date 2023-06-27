using EmployeeManagement.Models;


namespace EmployeeManagement.Data
{
    public static class FakeData
    {
        public static List<Employee> Employees;

        static FakeData()  // create fake data only first time.
        {
            Employees = new List<Employee>()
            {
                new Employee() { ID= 1, FullName = "Mert", LastName = "Akdemir", Job = "Computer Engineer"},
                new Employee() { ID= 2, FullName = "Elif Gül", LastName = "Bayraktar", Job = "Office Secretary"},
                new Employee() { ID= 3, FullName = "Irmak", LastName = "Deniz", Job = "Sales Manager"},
                new Employee() { ID= 4, FullName = "Ziya", LastName = "Ceceloğlu", Job = "Security"},
                new Employee() { ID= 5, FullName = "Pelin Su", LastName = "Gayreteden", Job = "Electrical-Electronics Engineer"},
            };
        }
    }
}
