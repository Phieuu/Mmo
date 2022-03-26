using System.Text;

namespace CheckIn;

public static class MenuHelper
{
    public static async Task Excute()
    {
        string userName;
        string password;
        DateTimeOffset dateTimeCheckIn;
        DateTimeOffset dateTimeCheckOut;

        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine($"[{DateTime.Now}] Chào mừng đến công cụ hỗ trợ điểm danh");
        Console.Write($"[{DateTime.Now}] Vui lòng nhập tài khoản: ");
        userName = await InputHelper.InputString();
        Console.Write($"[{DateTime.Now}] Vui lòng nhập mật khẩu: ");
        password = await InputHelper.InputString();
        Console.Write($"[{DateTime.Now}] Thời gian Check In (10:00) : ");
        dateTimeCheckIn = await InputHelper.InputDateTime();
        Console.Write($"[{DateTime.Now}] Thời gian Check In (19:00) : ");
        dateTimeCheckOut = await InputHelper.InputDateTime();

        Console.WriteLine($"[{DateTime.Now}] Xin chào [{userName}] thời gian check in [{dateTimeCheckIn.ToString("HH:mm")}] thời gian check out [{dateTimeCheckOut.ToString("HH:mm")}]");
        await TelegramHelper.SendMessage($"[{DateTime.Now}] Xin chào tài khoản [{userName}] thời gian check in [{dateTimeCheckIn.ToString("HH:mm")}] thời gian check out [{dateTimeCheckOut.ToString("HH:mm")}]");

        while (true)
        {
            if (DateTimeOffset.Now.TimeOfDay > dateTimeCheckOut.TimeOfDay && DateTimeOffset.Now.TimeOfDay < dateTimeCheckOut.AddMinutes(15).TimeOfDay)
            {
                Console.WriteLine($"[{DateTime.Now}] Check out");
                await CheckInHelper.CheckInOut(userName, password);
                await Task.Delay(TimeSpan.FromHours(14));
            }
            else if (DateTimeOffset.Now.TimeOfDay > dateTimeCheckIn.AddMinutes(-15).TimeOfDay && DateTimeOffset.Now.TimeOfDay < dateTimeCheckIn.TimeOfDay)
            {
                Console.WriteLine($"[{DateTime.Now}] Check in");
                await CheckInHelper.CheckInOut(userName, password);
                await Task.Delay(TimeSpan.FromHours(9));
            }
            else
            {
                await Task.Delay(TimeSpan.FromMinutes(5));
                Console.WriteLine($"[{DateTime.Now}] Running ...");
            }
        }
    }
}