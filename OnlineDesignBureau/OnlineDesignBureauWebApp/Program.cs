using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineDesignBureauWebApp
{
    public class Program
    {
        // ������ �� ����� ����� � ������ ������� https://drive.google.com/file/d/1-n8R3iTqIGo75zp9-VqaKUVcxneKSALK/view?usp=sharing
        public static void Main(string[] args)
        {
            // � ������ ����� ��������� ������������ ��� ����������, ������� ����� ���������������, �������� � �����������
            CreateHostBuilder(args).Build().Run(); // �� ����, ��� ������ CreateHostBuilder �� �������� Build(),
                                                   // ������� ���������� ��� ����, � ����� �� ���� ���� ���������.
        }

        public static IHostBuilder CreateHostBuilder(string[] args) // �����, ������� ���������� IHostBuilder. ����������, ������� ����� ������� ����,
                                                                    // ������� ������� �����-�� ������� � �� ���� ��������
            {                                                                     
                return Host.CreateDefaultBuilder(args) // ��������������� ����������� ���������
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>(); // ���������� ��������� ��� ��������� ��������� ��������, ������� ��������� � ������ Startup
                    });
            }
    }
}
