using System;
using System.Collections.Generic;
using OnlineShopWebApp.Models;

//временный интерфейс, для обучения тестированию
namespace OnlineShopWebApp.Interfase
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        void CreateEmployee(Employee employee);
        Employee Find(Guid Id);
        void Remove(Guid Id);
    }
}
