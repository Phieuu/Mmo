using MobileApp.Models.RequestProviderModel;
using MobileApp.Models.Telegram;
using MobileApp.Configurations;
using MobileApp.Services.RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MobileApp.Services.Telegram
{
    public class TelegramService : ITelegramService
    {
        private IRestSharpService _restSharpService;
        public TelegramService(IRestSharpService restSharpService)
        {
            _restSharpService = restSharpService;
        }
        public async Task<TelegramModel> SendMessageToTelegram(string idChat, string message, string token = null)
        {
            try
            {

                var uri = AppConstants.UriApiTelegram + token + "/sendMessage";

                var para = new List<RequestParameter>();
                para.Add(new RequestParameter("chat_id", idChat));
                para.Add(new RequestParameter("text", message));
                var data = await _restSharpService.PostAsync(uri, para);
                return JsonConvert.DeserializeObject<TelegramModel>(data);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return null;
            }
        }
    }
}