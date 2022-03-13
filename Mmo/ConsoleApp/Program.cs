using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
           // DoiTenFile();
        }

        private static void DoiTenFile()
        {
            var ls = Directory.GetFiles(Directory.GetCurrentDirectory() + "\\Data\\");
            foreach (var s in ls)
            {
                var duoi = Path.GetExtension(s);
                var nameFile = Path.GetFileName(s);
                nameFile = nameFile.Replace(duoi, "");
                nameFile = nameFile.Replace("Data", "") + duoi;

                File.Move(s, Path.GetDirectoryName(s) + "\\" + nameFile);
            }
        }

        private static async Task DoiTenFileInObject()
        {
            var json = await File.ReadAllTextAsync(Directory.GetCurrentDirectory() + "\\Data\\mydata1.json");
            var ls = JsonSerializer.Deserialize<List<GameModel>>(json);
            foreach (var gameModel in ls)
            {
                gameModel.NameFile = "abc" + gameModel.NameFile;
            }

            var json1 = JsonSerializer.Serialize(ls);
            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + "\\Data\\mydata.json", json1);
        }

        private static async Task DownloadFile()
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
            await File.WriteAllTextAsync(Directory.GetCurrentDirectory() + "\\Data\\mydata1.json", json);
        }
    }
}
