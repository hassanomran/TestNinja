using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        void RemoveById(int id);
    }
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _db;

        public EmployeeRepository(EmployeeContext db){
            _db = db;
        }

        public Employee GetById(int id)
        {
            var employee = _db.Employees.Find(id);
            return employee;
        }

        public void RemoveById(int id)
        {
            var employee = GetById(id);
            if (employee != null) return;
            _db.Employees.Remove(employee);
            _db.SaveChanges();
        }
    }
}
