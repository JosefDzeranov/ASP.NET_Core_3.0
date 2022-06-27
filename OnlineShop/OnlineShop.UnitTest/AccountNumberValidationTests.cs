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

        //[Fact] - это тест, не принимающий параметров
        //[Theory] — это тест, принимающий параметры, при этом может быть несколько сценариев. 
        [Fact] 
        //Принцип именования методов: [Тестируемый метод]_[Сценарий]_[Ожидаемое поведения]
        //Название метода подразумевает, что мы тестируем действительный номер учетной записи и что метод тестирования должен возвращать true
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            //Для выражения мы вызываем метод IsValid из класса AccountNumberValidation и передаем действительный номер счета.
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }

        // В классе AccountNumberValidation метод IsValid содержит проверки для первой, средней и последней части номера счета.
        // Поэтому мы собираемся написать тесты для всех этих ситуаций.

        //Начнем с теста, в котором неверна первая часть:
        [Fact]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse_bad_option()
        {
            //Мы ожидаем, что наш тест вернет false, если у нас неправильный номер счета.
            //Поэтому мы используем метод False()с предоставленным выражением
            Assert.False(_validation.IsValid("1234-3454565676-23"));
        }

        //теперь, если мы хотим протестировать номер учетной записи с 2 цифрами для первой части
        //(мы тестировали только с 4 цифрами), нам придется снова написать тот же метод, только с другим номером учетной записи.
        //Очевидно, это не лучший сценарий.
        //Чтобы улучшить это, мы собираемся изменить этот метод тестирования,
        //удалив атрибут [Fact]и добавив [Theory] и [InlineData] атрибуты:
        [Theory]
        [InlineData("1234-3454565676-23")]
        [InlineData("12-3454565676-23")]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse(string accountNumber)
        {
            Assert.False(_validation.IsValid(accountNumber));
        }

        //напишем дополнительные тесты для номера нашей учетной записи:
        [Theory]
        [InlineData("123-345456567-23")]
        [InlineData("123-345456567633-23")]
        public void IsValid_AccountNumberMiddlePartWrong_ReturnsFalse(string accNumber)
        {
            Assert.False(_validation.IsValid(accNumber));
        }
        [Theory]
        [InlineData("123-3434545656-2")]
        [InlineData("123-3454565676-233")]
        public void IsValid_AccountNumberLastPartWrong_ReturnsFalse(string accNumber)
        {
            Assert.False(_validation.IsValid(accNumber));
        }

        //В методе IsValid мы проверяем, что оба разделителя должны быть знаками минус.
        //Если это окажется не так, то мы сгенерируем исключение.
        //Итак, давайте напишем для этого тест:
        [Theory]
        [InlineData("123-345456567633=23")]
        [InlineData("123+345456567633-23")]
        [InlineData("123+345456567633=23")]
        public void IsValid_InvalidDelimiters_ThrowsArgumentException(string accNumber)
        {
            //Чтобы проверить исключение, мы должны использовать метод Throwsс типом исключения в качестве значения T
            Assert.Throws<ArgumentException>(() => _validation.IsValid(accNumber)); 
            //мы используем лямбда-выражение внутри метода Throws, которое немного отличается от того, что мы использовали раньше.
        }
        //Сделав это, проверим результат: тест не прошел
        //Если быть точнее, два из сценариев не прошли, а один прошел. Это означает, что наша проверка в методе IsValid неверна.
        //Необходимо исправлять тестируемый метод
    }
}
