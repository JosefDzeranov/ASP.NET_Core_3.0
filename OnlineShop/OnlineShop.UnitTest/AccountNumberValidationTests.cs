using System;
using OnlineShopWebApp.Validation;
using Xunit;

namespace OnlineShop.UnitTest
{
    public class AccountNumberValidationTests
    {
        //�� ���������� ������������ ������ _validation �� ����� ��������� �������� � ���� ������.
        private readonly AccountNumberValidation _validation;

        //������ ������ - ������� ��� � ������������, � ����� ������ ������������, ����� �� ��� �����.
        //����� ������� �� ������������� ���������� �������� ���������� �������
        public AccountNumberValidationTests()
        {
            _validation = new AccountNumberValidation();
        }


        [Fact]
        //������� ����������: [����������� �����]_[��������]_[��������� ���������]
        //�������� ������ �������������, ��� �� ��������� �������������� ����� ������� ������ � ��� ����� ������������ ������ ���������� true
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            //��� ��������� �� �������� ����� IsValid �� ������ AccountNumberValidation � �������� �������������� ����� �����.
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }
    }
}
