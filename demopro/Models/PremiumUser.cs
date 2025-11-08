using demopro.Services;
namespace demopro.Models
{
    public class PremiumUser : BaseUser
    {
        public override bool IsPremium { get; set; } = true;
        public PremiumUser()
        {
            predictor = new SmartCount();
        }
        public override CoffeeShop? PredictNextShop(List<UserVisitRecord> history, List<CoffeeShop> allShops)
        {
            if (predictor is SmartCount smartPredictor)
            {
                return smartPredictor.Predict(history, allShops);
            }
            return null; // Fallback if the predictor is not of type SmartCount
        }
    }
}
