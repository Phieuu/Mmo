using FastExpressionCompiler.LightExpression;

namespace MobileApp.Models
{
    public class UpdateNew88iOsModel
    {
        public bool IsUpdate { get; set; }

        public string AppName { get; set; }
        public AppUrlModel Urls { get; set; } = new AppUrlModel();
    }
}