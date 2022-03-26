// See https://aka.ms/new-console-template for more information

using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

Console.WriteLine("Hello, World!");
var option = new ChromeOptions();
var driver = new ChromeDriver(option);
var rd = new Random();
Console.OutputEncoding = Encoding.Unicode;
Console.InputEncoding = Encoding.Unicode;

driver.Navigate().GoToUrl("https://hub.tri-7.com/stream/");

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(2, 4));

// username
var userName = driver.FindElement(By.Name("USER_LOGIN"));
userName.SendKeys("peterl");

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(2, 4));

// passwd
var passwd = driver.FindElement(By.Name("USER_PASSWORD"));
passwd.SendKeys("D1fc0nku.,@");

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(2, 5));

// ghi nho mat khau
var remember = driver.FindElement(By.ClassName("login-item-checkbox-label"));
remember.Click();

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(2, 3));

// click login
var login = driver.FindElement(By.ClassName("login-btn"));
login.Click();

driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(rd.Next(3, 4));

var checkLogin = driver.FindElement(By.ClassName("errortext"));
if (checkLogin != null)
{
    Console.WriteLine($"Đăng nhập lỗi: {checkLogin.Text}");
}
else
{
    Console.WriteLine($"Đăng nhập thành công !");
}

//driver.SwitchTo().NewWindow(WindowType.Tab);

Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
screenshot.SaveAsFile("screenshot.png", ScreenshotImageFormat.Png);

driver.Quit();