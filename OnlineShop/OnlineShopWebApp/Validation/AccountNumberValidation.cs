using System;

namespace OnlineShopWebApp.Validation
{
    //мы хотим убедиться, что AccountNumber состоит из трех частей разной длины (3, 10 и 2).
    //Кроме того, мы хотим, чтобы в качестве разделителя использвался знак минус.
    //если разделители недействительны, мы генерируем исключение.
    //Если какая-либо из частей AccountNumber недействительна, мы возвращаем false.
    //Наконец, если все идет хорошо, мы возвращаем true.
    public class AccountNumberValidation
    {
        private const int startingPartLength = 3;
        private const int middlePartLength = 10;
        private const int lastPartLength = 2;
        public bool IsValid(string accountNumber)
        {
            var firstDelimiter = accountNumber.IndexOf('-');
            var secondDelimiter = accountNumber.LastIndexOf('-');

            if (firstDelimiter == -1 || secondDelimiter == -1)
                throw new ArgumentException();

            var firstPart = accountNumber.Substring(0, firstDelimiter);
            if (firstPart.Length != startingPartLength)
                return false;

            var tempPart = accountNumber.Remove(0, startingPartLength + 1);
            var middlePart = tempPart.Substring(0, tempPart.IndexOf('-'));
            if (middlePart.Length != middlePartLength)
                return false;

            var lastPart = accountNumber.Substring(secondDelimiter + 1);
            if (lastPart.Length != lastPartLength)
                return false;

            return true;

        }
    }
