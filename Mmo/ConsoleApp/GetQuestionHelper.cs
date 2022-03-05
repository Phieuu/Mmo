using RestSharp;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace ConsoleApp
{
    public static class GetQuestionHelper
    {
        public static async Task<string> DownloadFile(string url, int id)
        {
            var extension = Path.GetExtension(url);
            var client = new RestClient();
            var request = new RestRequest(url);
            var add = await client.DownloadDataAsync(request);
            await File.WriteAllBytesAsync(Directory.GetCurrentDirectory() + "\\Data\\" + id + extension, add);
            return id + extension;
        }
        public static async Task<GameModel> Get(int id)
        {
            var data = new GameModel();
            try
            {
                var client = new RestClient("https://lazi.vn/dhbc/d/" + id);
                var request = new RestRequest();
                request.Method = Method.Get;
                request.Timeout = -1;
                var response = await client.ExecuteAsync(request);
                var content = response?.Content;
                data.Id = id;
                var urlRegex = Regex.Match(content,
                    @"<div class=""art_content"" style=""text-align: center;""><div class=""fill_all""><a href=""(.*?)""");
                data.Image = urlRegex?.Groups[1]?.Value;
                var answerRegexs = Regex.Matches(content, @"nen_trang_full(.*?)</div></div>");
                var anwserRegex = answerRegexs[1]?.Groups[1]?.Value;
                data.Answer = HttpUtility.HtmlDecode(Regex.Match(anwserRegex, @"><div class=""fill_all"">(.*?)</div>")?.Groups[1]?.Value);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return data;
        }
    }
}