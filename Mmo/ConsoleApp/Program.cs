using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cauhoi = new List<GameModel>();
            int id = 1;
            var random = new Random();
            while (true)
            {
                var data = await GetQuestionHelper.Get(id);
                if (data != null && !string.IsNullOrWhiteSpace(data.Image))
                {
                    var name = await GetQuestionHelper.DownloadFile(data?.Image, id);
                    data.NameFile = name;
                    cauhoi.Add(data);
                    Console.WriteLine($"Tai file: {id}");
                }
                else
                {
                    Console.WriteLine($"Ket thuc: {id}");
                    break;
                }
                id++;
                var rd = random.Next(3000, 5000);
                Console.WriteLine($"Tam dung: {rd}");
                await Task.Delay(rd);
            }

            var json = JsonSerializer.Serialize(cauhoi);
            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + "\\Data\\mydata.json", json);
        }
    }
}
