using System.Threading.Tasks;
using AUTO.HLT.MOBILE.VIP.Models.Telegram;

namespace MobileApp.Services.Telegram
{
    public interface ITelegramService
    {
        /// <summary>
        /// service gui tin nhan den group chat telegram
        /// </summary>
        /// <param name="idChat"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        Task<TelegramModel> SendMessageToTelegram(string idChat, string message, string token = null);
    }
}