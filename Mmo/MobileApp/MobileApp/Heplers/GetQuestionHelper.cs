using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MobileApp.Models;
using RestSharp;

namespace MobileApp.Heplers
{
    public static class GetQuestionHelper
    {
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
                data.Answer = Regex.Match(anwserRegex, @"><div class=""fill_all"">(.*?)</div>")?.Groups[1]?.Value;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return data;
        }
    }
}