using demopro.Components.Pages;
using demopro.Services;

namespace demopro.Models
{
    public class BaseUser
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public virtual bool IsPremium { get; set; } = false;

        public ICoffeePredictor predictor { get; set; } = new VisitCountPredictor();
        public virtual CoffeeShop? PredictNextShop(List<UserVisitRecord> history, List<CoffeeShop> allShops)
        {
            return predictor.Predict(history, allShops);
        }
    }
}

