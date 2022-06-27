using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfase
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        void CreateEmployee(Employee employee);
        Employee Find(Guid Id);
        void Remove(Guid Id);
        void Exit();
    }
}
