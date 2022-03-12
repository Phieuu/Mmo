using FastExpressionCompiler.LightExpression;

namespace MobileApp.Models
{
    public class UpdateWinBanCaAndroid1Model
    {
        public bool IsUpdate { get; set; }

        public string AppName { get; set; }
        public AppUrlModel Urls { get; set; } = new AppUrlModel();
    }
}