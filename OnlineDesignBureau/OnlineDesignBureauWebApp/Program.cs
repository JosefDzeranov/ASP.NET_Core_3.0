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
        /*
            ���������� � ������� lession2_2_1, lession2_2_2.
        ��� ����������, ��� � ������ ����� 2 �������, �.�. ������� ������������ ������ ��� ���� ������ � �� ������� ������, ����� �������� ������� 1
        � ���� ������� ������ ���� 2 ���� ������, ��� ����� � ������, ������, ������ ������ ������������� �� ��������������� ���������.
        � ����������� ����������� ������ ����� ����� - ���������, � ������� ��������� ��������� ������� ������ ������ (������������), ���������� ��������. 
        � ���-�� � ��������� ��������� ������ � ������� (��������������� ��� ������ ������).
        � ���� ��������� ����� ��������� ������� �������, ������� ������� � �������, � ���������. (���� �������? ���� ��������� �� ���?)
        � ��������� ���������� ����� � �� ����� ��������.
        ����� �������� ������ ���������� �������, ��� �����.
        ������� ����������� ���������� (https://localhost:5001/product/save) � ������ json. 
        ����������� ���������� ����� ������� ����� ��������� �������� https://localhost:5001/product/AddProduct?name=59-70&cost=32000  
         */

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run(); 
        }

        public static IHostBuilder CreateHostBuilder(string[] args) 
            {                                                                     
                return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.UseStartup<Startup>();
                    });
            }
    }
}
