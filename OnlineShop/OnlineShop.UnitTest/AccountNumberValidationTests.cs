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

        //[Fact] - ��� ����, �� ����������� ����������
        //[Theory] � ��� ����, ����������� ���������, ��� ���� ����� ���� ��������� ���������. 
        [Fact] 
        //������� ���������� �������: [����������� �����]_[��������]_[��������� ���������]
        //�������� ������ �������������, ��� �� ��������� �������������� ����� ������� ������ � ��� ����� ������������ ������ ���������� true
        public void IsValid_ValidAccountNumber_ReturnsTrue()
        {
            //��� ��������� �� �������� ����� IsValid �� ������ AccountNumberValidation � �������� �������������� ����� �����.
            Assert.True(_validation.IsValid("123-4543234576-23"));
        }

        // � ������ AccountNumberValidation ����� IsValid �������� �������� ��� ������, ������� � ��������� ����� ������ �����.
        // ������� �� ���������� �������� ����� ��� ���� ���� ��������.

        //������ � �����, � ������� ������� ������ �����:
        [Fact]
        public void IsValid_AccountNumberFirstPartWrong_ReturnsFalse()
        {
            //�� �������, ��� ��� ���� ������ false, ���� � ��� ������������ ����� �����.
            //������� �� ���������� ����� False()� ��������������� ����������
            Assert.False(_validation.IsValid("1234-3454565676-23"));
        }
    }
}
