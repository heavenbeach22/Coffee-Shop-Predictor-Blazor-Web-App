using demopro.Models;

namespace demopro.Services
{
    public interface ICoffeePredictor
    {
        CoffeeShop? Predict(List<UserVisitRecord> history, List<CoffeeShop> allShops);
    }
}


