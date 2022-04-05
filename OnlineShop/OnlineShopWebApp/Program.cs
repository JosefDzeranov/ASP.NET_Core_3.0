using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OnlineShopWebApp
{
    //��������� �������� �����.� ����� ������� 3.1 "����������". ������� 3.1 ���� ��������� � ����� bilonenko_lesson3_1, ������� � ���� � ������ �����(�.�.������ 2 ����� � �������� 3.2)
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //test
                    webBuilder.UseStartup<Startup>();
                });
    }
}
