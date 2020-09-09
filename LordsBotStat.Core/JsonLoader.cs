namespace LordsBotStat.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;

    using LordsBotStat.Core.Dto;
    using LordsBotStat.Core.JsonDto;

    using Newtonsoft.Json;

    /// <summary>
    /// The Json loader.
    /// </summary>
    public class JsonLoader
    {
        private const string JsonFileMask = "guild-stats-*.json";

        private static readonly DateTime EpochBegin = new DateTime(1970, 1, 1);

        /// <summary>
        /// Loads the dir.
        /// </summary>
        /// <param name="dirName">Name of the dir.</param>
        /// <returns><see cref="Report"/>.</returns>
        public static Report LoadDir(string dirName)
        {
            if (!Directory.Exists(dirName))
            {
                return null;
            }

            var files = Directory.EnumerateFiles(dirName, JsonFileMask, SearchOption.TopDirectoryOnly);
            return LoadJson(files);
        }

        [SuppressMessage("ReSharper", "StyleCop.SA1310")]
        [SuppressMessage("ReSharper", "InconsistentNaming")]
        private static class Loot
        {
            public const int Level_2 = 1;

            public const int Level_3 = 2;
        }

        /// <summary>
        /// Loads the json.
        /// </summary>
        /// <param name="files">The files.</param>
        /// <returns><see cref="Report"/>.</returns>
        public static Report LoadJson(IEnumerable<string> files)
        {
            var loot = DeserializeJson(files);
            return Render(loot);
        }

        private static IList<LootReport> DeserializeJson(IEnumerable<string> files)
        {
            var loot = new List<LootReport>();

            foreach (var file in files)
            {
                try
                {
                    if (File.Exists(file))
                    {
                        loot.Add(LoadJson(file));
                    }
                    else if (Directory.Exists(file))
                    {
                        loot.AddRange(
                            DeserializeJson(
                                Directory.EnumerateFiles(file, JsonFileMask, SearchOption.TopDirectoryOnly)));
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            return loot;
        }

        private static LootReport LoadJson(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var report = serializer.Deserialize<LootReport>(jsonTextReader);
                return report;
            }
        }

        private static Report Render(ICollection<LootReport> loot)
        {
            // период за который собираем статистику
            var interval = loot.Select(x => x.DiscardTime).Where(time => !time.Equals(EpochBegin))
                .ToArray();

            var report = new Report
                             {
                                 // всего открыто коробок за указанный период
                                 TotalBoxes = loot.Sum(x => x.StatInfo.GiftsCollectedTotal)
                             };

            if (interval.Any())
            {
                report.DateFrom = interval.Min();
                report.DateTo = interval.Max();
            }

            var players = loot.SelectMany(p => p.BoxData)
                .GroupBy(box => box.PlayerName)
                .OrderBy(gr => gr.Key)
                    .ToArray();

            report.PlayersCount = players.Length;

            IList<RenderItem> renderItems = new List<RenderItem>();

            foreach (var gr in players)
            {
                // все коробки от монстров 2 уровня и выше
                var boxes = gr.Where(box => !box.IsPurchase && box.BoxLevel >= Loot.Level_2)
                    .ToArray();

                var playerName = gr.Key;
                if (string.IsNullOrEmpty(playerName))
                {
                    playerName = "Анонимно";
                }

                if (boxes.Any())
                {
                    var item = new RenderItem
                                   {
                                       PlayerName = playerName,
                                       Lvl2 = boxes.Count(box => box.BoxLevel == Loot.Level_2),
                                       Lvl3 = boxes.Count(box => box.BoxLevel >= Loot.Level_3),
                                       Paid = gr.Count(box => box.IsPurchase)
                                   };

                    renderItems.Add(item);
                }
            }

            report.Items = (IReadOnlyCollection<RenderItem>) renderItems;
            return report;
        }
    }
}
