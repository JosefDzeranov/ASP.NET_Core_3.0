using System;
using OnlineShopWebApp.Validation;
using Xunit;

namespace OnlineShop.UnitTest
{
    public class AccountNumberValidationTests
    {
        //Мы собираемся использовать объект _validation со всеми тестовыми методами в этом классе.
        private readonly AccountNumberValidation _validation;

        //лучший способ - создать его в конструкторе, а затем просто использовать, когда он нам нужен.
        //Таким образом мы предотвращаем повторение создания экземпляра объекта
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }


        [Fact]
        //Принцип именования: [Тестируемый метод]_[Сценарий]_[Ожидаемое поведения]
        //Название метода подразумевает, что мы тестируем действительный номер учетной записи и что метод тестирования должен возвращать true
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            //Для выражения мы вызываем метод IsValid из класса AccountNumberValidation и передаем действительный номер счета.
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }
    }
}
