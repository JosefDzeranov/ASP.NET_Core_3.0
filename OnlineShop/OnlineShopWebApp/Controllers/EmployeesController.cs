using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfase;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Validation;

namespace OnlineShopWebApp.Controllers
{
    //временный контроллер, для обучения тестированию
    public class EmployeesController : Controller
    {
        //мы используем Injection Dependency, чтобы внедрить интерфейс в наш контроллер.
        //Таким образом, наш контроллер зависит от логики репозитория через внедренный интерфейс.
        //Когда мы пишем тесты для нашего контроллера или любого другого класса в проекте,
        //мы должны изолировать эти зависимости.
        //
        //Изолирование зависимостей в тестовом коде дает несколько преимуществ:
        //   - Не нужно инициализировать все зависимости, чтобы возвращать правильные значения
        //   - Если наш тест завершился неудачно и мы не изолировали зависимость, мы не можем быть уверены,
        //что это не так из-за ошибки в контроллере или в этой зависимости
        //   - Когда зависимый код взаимодействует с реальной базой данных, как это делает наш репозиторий,
        //то выполнение тестового кода может занять больше времени из-за проблем с подключением или просто процесса выборки данных.

        private readonly IEmployeeRepository _repo;
        private readonly AccountNumberValidation _validation;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _repo = employeeRepository;
            _validation = new AccountNumberValidation();
        }
        public IActionResult Index()
        {
            //мы получаем всех сотрудников из базы данных и возвращаем представление с этими сотрудниками
            var employees = _repo.GetAll();
            return View(employees);
        }

        public IActionResult Create([Bind("Name,AccountNumber,Age")] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return View(employee);
            }

            _repo.CreateEmployee(employee);
            return RedirectToAction(nameof(Index));
        }
    }
}
