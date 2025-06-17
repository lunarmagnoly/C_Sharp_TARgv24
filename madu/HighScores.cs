using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace madu
{
    internal class HighScores
    {
        private string filePath = "results.txt";
        public void SaveResult(Player player)
        {
            File.AppendAllLines(filePath, new[] { $"{player.Name}:{player.Score}" });
        }
        public List<Player> GetAllResults()
        {
            var results = new List<Player>();
            if (!File.Exists(filePath)) return results;
            foreach (var line in File.ReadAllLines(filePath))
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int sc))
                    results.Add(new Player(parts[0], sc));
            }
            return results.OrderByDescending(r => r.Score).ToList();
        }
        public void ShowTopResults(int topN = 10)
        {
            Console.Clear();
            Console.WriteLine("Top results:");
            int i = 1;
            foreach (var p in GetAllResults().Take(topN))
                Console.WriteLine($"{i++}. {p.Name} — {p.Score}");
            Console.WriteLine("\nPress any button...");
            Console.ReadKey();
        }
    }
}
