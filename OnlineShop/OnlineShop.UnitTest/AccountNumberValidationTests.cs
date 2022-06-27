using System;
using OnlineShopWebApp.Validation;
using Xunit;

namespace OnlineShop.UnitTest
{
    public class AccountNumberValidationTests
    {
        //ћы собираемс€ использовать объект _validation со всеми тестовыми методами в этом классе.
        private readonly AccountNumberValidation _validation;

        //лучший способ - создать его в конструкторе, а затем просто использовать, когда он нам нужен.
        //“аким образом мы предотвращаем повторение создани€ экземпл€ра объекта
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }

        //[Fact] - это тест, не принимающий параметров
        //[Theory] Ч это тест, принимающий параметры, при этом может быть несколько сценариев. 
        [Fact] 
        //ѕринцип именовани€ методов: [“естируемый метод]_[—ценарий]_[ќжидаемое поведени€]
        //Ќазвание метода подразумевает, что мы тестируем действительный номер учетной записи и что метод тестировани€ должен возвращать true
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            //ƒл€ выражени€ мы вызываем метод IsValid из класса AccountNumberValidation и передаем действительный номер счета.
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }

        // ¬ классе AccountNumberValidation метод IsValid содержит проверки дл€ первой, средней и последней части номера счета.
        // ѕоэтому мы собираемс€ написать тесты дл€ всех этих ситуаций.

        //Ќачнем с теста, в котором неверна перва€ часть:
        [Fact]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse()
        {
            //ћы ожидаем, что наш тест вернет false, если у нас неправильный номер счета.
            //ѕоэтому мы используем метод False()с предоставленным выражением
            Assert.False(_validation.IsValid("1234-3454565676-23"));
        }
    }
}
