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
        bool isDateTimeCheckIn = false;
        bool isDateTimeCheckOut = false;

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
            if (DateTime.Now.DayOfWeek == DayOfWeek.Saturday)
            {
                await Task.Delay(TimeSpan.FromMinutes(2));
                Console.WriteLine($"[{DateTime.Now}] Thu 7 duoc nghi cac anh em duoc nghi quay thoi");
            }
            else
            {
                if (!isDateTimeCheckOut && DateTimeOffset.Now.TimeOfDay > dateTimeCheckOut.TimeOfDay && DateTimeOffset.Now.TimeOfDay < dateTimeCheckOut.AddMinutes(15).TimeOfDay)
                {
                    isDateTimeCheckOut = true;
                    isDateTimeCheckIn = false;
                    Console.Clear();
                    Console.WriteLine($"[{DateTime.Now}] Check out");
                    await CheckInHelper.CheckInOut(userName, password);
                }
                else if (!isDateTimeCheckIn && DateTimeOffset.Now.TimeOfDay > dateTimeCheckIn.AddMinutes(-15).TimeOfDay && DateTimeOffset.Now.TimeOfDay < dateTimeCheckIn.TimeOfDay)
                {
                    isDateTimeCheckIn = true;
                    isDateTimeCheckOut = false;
                    Console.Clear();
                    Console.WriteLine($"[{DateTime.Now}] Check in");
                    await CheckInHelper.CheckInOut(userName, password);
                }
                else
                {
                    await Task.Delay(TimeSpan.FromMinutes(2));
                    Console.WriteLine($"[{DateTime.Now}] Running ...");
                }
            }
        }
    }
}