using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShopWebApp.Controllers;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using Xunit;

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

            //передаём фиктивный объект с зависипостью в контроллер
            _controller = new EmployeesController(_mockRepo.Object);
        }

        // проверяем Index
        [Fact]
        public void Index_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.Index();
            //проверяем тип возвращаемого результата с помощью метода IsType
            Assert.IsType<ViewResult>(result);
        }

        //Напишем еще один тестовый метод, чтобы убедиться,
        //что наше действие Index возвращает точное количество сотрудников:

        //В предыдущем методе тестирования мы не использовали фиктивный объект,
        //потому что мы не использовали ни один из наших методов репозитория.
        //Мы только проверили тип нашего результата.
        //
        //В этом методе тестирования мы извлекаем данные из базы данных с помощью метода репозитория GetAll
        [Theory]
        [InlineData(2)]
        [InlineData(10)]
        public void Index_ActionExecutes_ReturnsExactNumberOfEmployees(int count)
        {
            var employeesInput = new List<Employee>();
            for (int i = 0; i < count; i++)
            {
                employeesInput.Add(new Employee());
            }
            //мы не хотим использовать конкретный репозиторий, а использовать имитацию,
            //и поэтому мы используем метод Setup, чтобы указать настройку для метода GetAll
            _mockRepo.Setup(repo => repo.GetAll())
                .Returns(employeesInput); //добавляем список объектов
            //мы должны использовать метод Returns, чтобы указать значение,
            //возвращаемое из имитационного метода GetAll
            var result = _controller.Index();

            var viewResult = Assert.IsType<ViewResult>(result);
            var employees = Assert.IsType<List<Employee>>(viewResult.Model);
            Assert.Equal(count, employees.Count);
        }

        // проверка на загрузку представления Create View
        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.Create();

            Assert.IsType<ViewResult>(result);
        }

        //проверка модели, и если она недействительна, мы возвращаем представление с объектом сотрудника.
        [Fact]
        public void Create_InvalidModelState_ReturnsView()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");
            var employee = new Employee { Age = 25, AccountNumber = "255-8547963214-41" };

            var result = _controller.Create(employee);

            var viewResult = Assert.IsType<ViewResult>(result); //проверяем, имеет ли результат тип ViewResult
            var testEmployee = Assert.IsType<Employee>(viewResult.Model); //проверяем, имеет ли модель тип Employee
            //Проверяем что вернем того же сотрудника, сравнивая значения свойств из объектов testEmployee и сотрудников
            Assert.Equal(employee.AccountNumber, testEmployee.AccountNumber);
            Assert.Equal(employee.Age, testEmployee.Age);
        }

        //напишем еще один тест, чтобы убедиться,
        //что метод CreateEmployee из нашего репозитория никогда не выполняется,
        //если состояние модели недопустимо
        [Fact]
        public void Create_InvalidModelState_CreateEmployeeNeverExecutes()
        {
            _controller.ModelState.AddModelError("Name", "Name is required");  //добавляем ошибку модели
            var employee = new Employee { Age = 25 }; //создаем недопустимый объект сотрудника

            _controller.Create(employee);

            //метод CreateEmployee - не должен выполняться, если модель недействительна
            //Это то, что мы проверяем с помощью метода Verify из фиктивного объекта.
            _mockRepo.Verify(x => x.CreateEmployee(It.IsAny<Employee>()), Times.Never);
            //Используя выражение It.IsAny, мы заявляем, что не имеет значения,
            //какой сотрудник передается в качестве параметра методу CreateEmployee.
            //Важно только то, что параметр имеет тип Employee.
            //Последний параметр метода Verify - это количество выполнений нашего метода.
            //В этой ситуации мы используем Times.Never, потому что мы не хотим,
            //чтобы метод CreateEmployee вообще выполнялся, если модель недействительна.

            
        }

        [Fact]
        public void Create_ActionExecuted_RedirectsToIndexAction()
        {
            var employee = new Employee
            {
                Name = "Test Employee",
                Age = 45,
                AccountNumber = "123-4356874310-43"
            };
            var result = _controller.Create(employee);

            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
        }
    }
}
