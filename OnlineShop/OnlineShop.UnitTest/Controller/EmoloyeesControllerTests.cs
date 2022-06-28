using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Interfase;

namespace OnlineShop.UnitTest.Controller
{
    public class EmployeesControllerTests
    {
        //Мы создаем фиктивный объект типа IEmployeeRepository внутри конструктора,
        //и, поскольку мы хотим протестировать логику контроллера,
        //мы создаем экземпляр этого контроллера с фиктивным объектом в качестве обязательного параметра
        private readonly Mock<IEmployeeRepository> _mockRepo;
        private readonly EmployeesController _controller;
        public EmployeesControllerTests()
        {
            _mockRepo = new Mock<IEmployeeRepository>();
            _controller = new EmployeesController(_mockRepo.Object);
        }
    }
}
