using demopro.Models;

namespace demopro.Services
{
    public class SmartCount : ICoffeePredictor
    {
        private const double VisitWeight = 1.5;
        public CoffeeShop? Predict(List<UserVisitRecord> history, List<CoffeeShop> allShops)
        {
            if (history == null || history.Count == 0)
                return null;

            var best = history
                .OrderByDescending(record => GetScore(record))
                .FirstOrDefault();

            return best? .ToCoffeeShop();
        }
        private double GetScore(UserVisitRecord record)
        {
            return (record.VisitCount * VisitWeight) + GetRecencyScore(record);
        }
        private double GetRecencyScore(UserVisitRecord shop)
        {
            if (shop.LastVisited.HasValue)
            {
                TimeSpan diff = DateTime.Now - shop.LastVisited.Value;
                return 1.0 / (diff.TotalDays + 1); // More recent = higher score
            }
            return 0;
        }
    }
}
