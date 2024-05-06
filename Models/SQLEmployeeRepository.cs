namespace EmployeeManagement.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Employee Add(Employee employee)
        {
            context.EmployeesNew.Add(employee);
            context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = context.EmployeesNew.Find(Id);
            if (employee != null)
            {
                context.EmployeesNew.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return context.EmployeesNew;
        }

        public Employee GetEmployee(int Id)
        {
            return context.EmployeesNew.Find(Id);
        }

        public Employee Update(Employee employeeUpdate)
        {
            var employee = context.EmployeesNew.Attach(employeeUpdate);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeUpdate;
        }
    }
}
