using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CheckIn;

public static class CheckInHelper
{
    /// <summary>
    /// check in check out
    /// </summary>
    /// <param name="user">Tài khoản</param>
    /// <param name="pass">Mật khẩu</param>
    /// <returns></returns>
    public static async Task CheckInOut(string user, string pass)
    {
        var rd = new Random();
        string str;
        var option = new ChromeOptions();
        var driver = new ChromeDriver(option);
        Console.OutputEncoding = Encoding.Unicode;
        Console.InputEncoding = Encoding.Unicode;

        driver.Navigate().GoToUrl("https://hub.tri-7.com/stream/");

        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(2, 4));

        // username
        var userName = driver.FindElement(By.Name("USER_LOGIN"));
        userName.SendKeys(user);

        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));

        // passwd
        var passwd = driver.FindElement(By.Name("USER_PASSWORD"));
        passwd.SendKeys(pass);

        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));

        // ghi nho mat khau
        var remember = driver.FindElement(By.ClassName("login-item-checkbox-label"));
        remember.Click();

        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));

        // click login
        var login = driver.FindElement(By.ClassName("login-btn"));
        login.Click();

        if (driver.Title == "Authorization")
        {
            Console.WriteLine($"[{DateTime.Now}] Chua dang nhap thanh cong");
            driver.Quit();
            TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Chua dang nhap thanh cong");
            return;
        }
        else if (driver.Title == "TRI7 HUB")
        {
            Console.WriteLine($"[{DateTime.Now}] Dang nhap thanh cong");
            TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Dang nhap thanh cong");
        }

        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));

        // mo popup check in out
        var checkIn = driver.FindElement(By.Id("timeman-container"));
        checkIn.Click();

        var labelChange = driver.FindElement(By.ClassName("tm-popup-change-time-link"));
        str = labelChange.Text;
        // check in out
        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));
        var clickCheckIn = driver.FindElement(By.ClassName("tm-popup-button-handler"));
        clickCheckIn.Click();

        await Task.Delay(TimeSpan.FromSeconds(rd.Next(10, 15)));

        var labelChange2 = driver.FindElement(By.ClassName("tm-popup-change-time-link"));
        string str2 = labelChange2.Text;
        if (str != str2)
        {
            if (str2 == "Change clock-out time")
            {
                Console.WriteLine($"[{DateTime.Now}] Check in done");
                TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Check in done");
            }
            else if (str2 == "Change clock-in time")
            {
                Console.WriteLine($"[{DateTime.Now}] Check out done");
                TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Check out done");
            }
        }
        else
        {
            if (str2 == "Change clock-out time")
            {
                Console.WriteLine($"[{DateTime.Now}] Check out error");
                TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Check out error");
            }
            else if (str2 == "Change clock-in time")
            {
                Console.WriteLine($"[{DateTime.Now}] Check in error");
                TelegramHelper.SendMessage($"[{DateTime.Now}] [{user}] Check in error");
            }
        }

        driver.Quit();
    }
}