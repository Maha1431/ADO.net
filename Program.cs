using System;

namespace EmployeeDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            AddressbookModel model = new AddressbookModel();
            EmployeeRepo repo = new EmployeeRepo();
            repo.Add(model);
            repo.DeletePerson(model);
            repo.UpdateData(model);
            repo.RetrivePersonCityOrState(model);
        }
    }
}
