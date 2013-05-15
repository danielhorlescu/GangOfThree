using MVCSkeleton.Presentation.Models;
using TechTalk.SpecFlow;

namespace MVCSkeleton.Requirements.Context
{
    public class ProductContext
    {
        private const string key = "ProductContext";
        private static ProductContext _instance;

        public static ProductContext Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(key))
                {
                    _instance = new ProductContext();
                    ScenarioContext.Current[key] = _instance;
                }
                return _instance;
            }
        }

        public ProductModel Product { get; set; }
    }
}