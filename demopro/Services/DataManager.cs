using demopro.Models;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace demopro.Services
{
    public class DataManager
    {
        private readonly IWebHostEnvironment _env; // Environment to access web root path
        private readonly string _visitCountPath;
        private readonly string _fullHistoryPath;

        public DataManager(IWebHostEnvironment env)
        {
            _env = env;
            _visitCountPath = Path.Combine(_env.WebRootPath, "data", "history.json");
            _fullHistoryPath = Path.Combine(_env.WebRootPath, "data", "fullhistory.json");
        }

        //load cafe shops
        //read json parses through jsonroot
        //map each feature to CoffeeShop model
        // assign random rating between 3.5 and 5.5
        //sync visit counts to history.json
        public async Task<List<CoffeeShop>> LoadCafesAsync()
        {
            var filePath = Path.Combine(_env.WebRootPath, "data", "coffeeshop.json");
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"Could not find {filePath}");

            var json = await File.ReadAllTextAsync(filePath);
            var shops = GeoJsonParser.Parse(json); //new
            //origrinally:  var geoData = JsonSerializer.Deserialize<GeoJsonRoot>(json);
            //var shops = new List<CoffeeShop>();
            var rand = new Random();

            var visitCounts = LoadVisitCounts();
            foreach (var shop in shops)
            {
                if (visitCounts.TryGetValue(shop.Name, out int count))
                    shop.VisitCount = count;
            }

            return shops;
        }

        // Load and save visit counts to history.json
        private Dictionary<string, int> LoadVisitCounts()
        {
            if (!File.Exists(_visitCountPath)) return new Dictionary<string, int>();

            try
            {
                string json = File.ReadAllText(_visitCountPath);
                return JsonSerializer.Deserialize<Dictionary<string, int>>(json) ?? new();
            }
            catch
            {
                Console.WriteLine("history.json is broken. Resetting visit count.");
                return new();
            }
        }
        // Save visit counts to history.json
        private void SaveVisitCounts(Dictionary<string, int> counts)
        {
            string json = JsonSerializer.Serialize(counts, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_visitCountPath, json);
        }
        // Add a visit to a coffee shop and update the count in history.json
        public int AddVisit(string coffeeShopName)
        {
            var counts = LoadVisitCounts();

            if (counts.ContainsKey(coffeeShopName))
                counts[coffeeShopName]++;
            else
                counts[coffeeShopName] = 1;

            SaveVisitCounts(counts);
            return counts[coffeeShopName];
        }
        //deal in fullhistory.json
        public async Task<List<UserVisitRecord>> LoadHistoryAsync()
        {
            if (!File.Exists(_fullHistoryPath)) return new List<UserVisitRecord>();

            try
            {
                var json = await File.ReadAllTextAsync(_fullHistoryPath);
                return JsonSerializer.Deserialize<List<UserVisitRecord>>(json) ?? new();
            }
            catch
            {
                Console.WriteLine("⚠️ fullhistory.json is broken. Resetting history.");
                return new();
            }
        }
        //deal with async version of AddVisitToFullHistory
        public async Task AddVisitToFullHistoryAsync(string coffeeShopName)
        {
            List<UserVisitRecord> records = await LoadHistoryAsync();

            var existing = records.FirstOrDefault(r => r.CoffeeShopName == coffeeShopName);
            if (existing != null)
            {
                existing.VisitCount++;
                existing.LastVisited = DateTime.UtcNow;
            }
            else
            {
                records.Add(new UserVisitRecord
                {
                    CoffeeShopName = coffeeShopName,
                    VisitCount = 1,
                    LastVisited = DateTime.UtcNow
                });
            }

            var json = JsonSerializer.Serialize(records, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_fullHistoryPath, json);
        }

        public async Task<int> MarkCoffeeShopVisitedAsync(string coffeeShopName)
        {
            // Update visit count in history.json
            int newCount = AddVisit(coffeeShopName);

            // Update detailed record in fullhistory.json
            await AddVisitToFullHistoryAsync(coffeeShopName);

            return newCount;
        }
        public async Task ClearVisitHistoryAsync()
        {
            string historyPath = Path.Combine(AppContext.BaseDirectory, "history.json");
            string fullHistoryPath = Path.Combine(AppContext.BaseDirectory, "fullhistory.json");

            try
            {
                // You can either delete the files or overwrite them with empty content
                if (File.Exists(_visitCountPath))
                    await File.WriteAllTextAsync(_visitCountPath, "{}"); // Empty JSON object for Dictionary

                if (File.Exists(_fullHistoryPath))
                    await File.WriteAllTextAsync(_fullHistoryPath, "[]"); // Empty list for visit records

                Console.WriteLine("Visit history cleared.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error clearing history: {ex.Message}");
            }
        }
    }
}
