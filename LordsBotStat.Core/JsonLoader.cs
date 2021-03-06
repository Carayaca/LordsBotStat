﻿using NLog;

namespace LordsBotStat.Core
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Linq;

    using LordsBotStat.Core.Dto;
    using LordsBotStat.Core.JsonDto;

    /// <summary>
    /// The Json loader.
    /// </summary>
    public static class JsonLoader
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        private const string JsonFileMask = "guild-stats-*.json";

        /// <summary>
        /// Loads the dir.
        /// </summary>
        /// <param name="dirName">Name of the dir.</param>
        /// <returns><see cref="Report"/>.</returns>
        public static Report LoadDir(string dirName)
        {
            Log.Debug("Loading directory: {name}", dirName);
            if (!Directory.Exists(dirName))
            {
                Log.Warn("Directory {name} is not exist", dirName);
                return null;
            }

            var files = Directory.EnumerateFiles(dirName, JsonFileMask, SearchOption.TopDirectoryOnly);
            return LoadJson(files);
        }

        [SuppressMessage("ReSharper", "StyleCop.SA1309")]
        private static class LootLevel
        {
            /// <summary>
            /// LEVEL 2.
            /// </summary>
            public const int _2 = 1;

            /// <summary>
            /// LEVEL 3.
            /// </summary>
            public const int _3 = 2;
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
                        loot.Add(Json.LoadFrom<LootReport>(file));
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

            Log.Debug("Loaded {N} file(s)", loot.Count);
            return loot;
        }

        private static Report Render(ICollection<LootReport> loot)
        {
            // период за который собираем статистику
            var interval = loot.SelectMany(x => x.BoxData, (_, box) => box.RcvTime)
                .ToArray();

            var report = new Report
                             {
                                 // всего открыто коробок за указанный период
                                 TotalBoxes = loot.Sum(x => x.StatInfo.GiftsCollectedTotal)
                             };

            if (interval.Any())
            {
                report.DateFrom = interval.Min().Date;
                report.DateTo = interval.Max().AddDays(1).Date;
            }

            Log.Debug("Report period: {min} - {max}", interval.Min(), interval.Max());

            var players = loot.SelectMany(p => p.BoxData)
                .GroupBy(box => box.PlayerName)
                .OrderBy(gr => gr.Key)
                    .ToArray();

            report.PlayersCount = players.Length;
            Log.Debug("Report players: {N}", report.PlayersCount);

            IList<RenderItem> renderItems = new List<RenderItem>();

            foreach (var gr in players)
            {
                // все коробки от монстров 2 уровня и выше
                var boxes = gr.Where(box => !box.IsPurchase && box.BoxLevel >= LootLevel._2)
                    .ToArray();

                if (boxes.Any())
                {
                    var item = new RenderItem(report)
                                   {
                                       PlayerName = gr.Key.Or("Анонимно"),
                                       Lvl2 = boxes.Count(box => box.BoxLevel == LootLevel._2),
                                       Lvl3 = boxes.Count(box => box.BoxLevel >= LootLevel._3),
                                       Paid = gr.Count(box => box.IsPurchase)
                                   };

                    renderItems.Add(item);
                }
            }

            Log.Debug("Total counts: LVL 2: {LVL2}, LVL 3+: {LVL3}, Paid: {Paid}",
                renderItems.Sum(p => p.Lvl2),
                renderItems.Sum(p => p.Lvl3),
                renderItems.Sum(p => p.Paid));

            report.Items = (IReadOnlyCollection<RenderItem>) renderItems;
            return report;
        }
    }
}
