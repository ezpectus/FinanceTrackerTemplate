using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinanceTrackerTemplate.Models;
using FinanceTrackerTemplate.Models.Repositories.Interfaces;
using System.Text.Json;
using System.IO;
using FinanceTrackerTemplate.Services.Interfaces;
using FinanceTrackerTemplate.UI;
using FinanceTrackerTemplate.Interfaces;



namespace FinanceTrackerTemplate.Services
{
    public class JsonStorageRepository : IDataStorageService
    {
        private const string FilePath = "data.json";

        public void Save(DataStorage storage)
        {
            var json = JsonSerializer.Serialize(storage, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public DataStorage Load()
        {
            if (!File.Exists(FilePath))
            {
                var emptyStorage = new DataStorage();
                Save(emptyStorage);
                Console.WriteLine($"[INFO] File {FilePath} not found. Created new.");
                return emptyStorage;
            }

            var json = File.ReadAllText(FilePath);
            var storage = JsonSerializer.Deserialize<DataStorage>(json);
            return storage ?? new DataStorage();
        }
    }

}
