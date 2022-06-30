using System;
using System.Collections.Generic;
using System.Linq;
using OnlineShop.Common;
using OnlineShop.Common.Interface;
using OnlineShop.Db;
using OnlineShop.Db.Interfase;
using OnlineShop.Db.Models;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp
{
    //временный класс для обучения тестированию
    public class EmployeeRepository : IEmployeeRepository
    {
        private IWorkWithData JsonStorage { get; }
        private readonly List<Employee> employes;

        private const string nameSave = "employes";
        
        public EmployeeRepository()
        {
            JsonStorage = new JsonWorkWithData(nameSave);
            employes = new List<Employee>();
        }
        

        public List<Employee> GetAll()
        {
            return employes;
        }

        public Employee Find(Guid id)
        {
            return employes.FirstOrDefault(x => x.Id == id);
        }
        

        public void CreateEmployee(Employee employee)
        {
            Guid idGuid = Guid.NewGuid();
            employee.Id = idGuid;
            employes.Add(employee);
            Save();
        }
        public void Remove(Guid id)
        {
            employes?.RemoveAll(x => x.Id == id);
            Save();
        }

        private void Save()
        {
            JsonStorage.Write(employes);
        }
    }
}
