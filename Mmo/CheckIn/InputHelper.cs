namespace CheckIn;

public static class InputHelper
{
    public static async Task<DateTimeOffset> InputDateTime()
    {
        DateTimeOffset time;

        var inputTime = await InputString();
        while (true)
        {
            var isTime = DateTimeOffset.TryParse(inputTime, out var result);
            if (isTime)
            {
                time = result;
                break;
            }
            Console.Write("\nVui long nhap lai: ");
            inputTime = await InputString();
        }

        return time;
    }
    /// <summary>
    /// Nhập string
    /// </summary>
    /// <returns></returns>
    public static Task<string> InputString()
    {
        string str;

        while (true)
        {
            str = Console.ReadLine();
            if (!string.IsNullOrEmpty(str) || !string.IsNullOrWhiteSpace(str))
            {
                break;
            }
            Console.Write("\nVui long nhap lai: ");
        }

        return Task.FromResult(str);
    }
}