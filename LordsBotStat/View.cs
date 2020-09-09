namespace LordsBotStat
{
    using System;
    using System.Linq;

    using Alba.CsConsoleFormat;

    using LordsBotStat.Core.Dto;

    /// <summary>
    /// The View class.
    /// </summary>
    public static class View
    {
        private static readonly LineThickness StrokeHeader = new LineThickness(LineWidth.None, LineWidth.Double);
        private static readonly LineThickness StrokeRight = new LineThickness(LineWidth.None, LineWidth.None, LineWidth.Single, LineWidth.None);

        /// <summary>
        /// Renders the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        public static void Render(Report report)
        {
            var doc = new Document
                          {
                              Background = ConsoleColor.Black,
                              Color = ConsoleColor.Gray,
                              Children =
                                  {
                                      new Grid
                                          {
                                              StrokeColor = ConsoleColor.DarkGray,
                                              Columns =
                                                  {
                                                      new Column { Width = GridLength.Auto, MinWidth = 25 }, // PLAYER
                                                      new Column { Width = GridLength.Auto }, // LEVEL 2
                                                      new Column { Width = GridLength.Auto }, // LEVEL 3
                                                      new Column { Width = GridLength.Auto }, // PAID
                                                      new Column { Width = GridLength.Auto }, // SCORE
                                                      new Column { Width = GridLength.Auto }, // STATUS
                                                      new Column { Width = GridLength.Auto } // DEBT
                                                  },
                                              Children =
                                                  {
                                                      new Cell("PLAYER") { Color = ConsoleColor.White },
                                                      new Cell("LEVEL 2") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("LEVEL 3+") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("PAID") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("SCORE") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("STATUS") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("DEBT") { Color = ConsoleColor.White, Align = Align.Center },
                                                      report.Items.Select(
                                                          x => new[]
                                                                   {
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Color = ConsoleColor.Yellow,
                                                                               Children = { x.PlayerName }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Lvl2 == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Lvl2 }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Lvl3 == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Lvl3 }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Paid == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Paid }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Children = { x.Score }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Debt == 0 ? ConsoleColor.Green : ConsoleColor.Red,
                                                                               Children = { x.Status }
                                                                           },
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Children = { x.Debt == 0 ? "-" : x.Debt.ToString() }
                                                                           }
                                                                   })
                                                  }
                                          }
                                  }
                          };

            ConsoleRenderer.RenderDocument(doc);

            if (report.LazyPlayers.Any())
            {
                Console.WriteLine("Количество игроков без отчетов: {0}", report.LazyPlayers.Count);
                foreach (var player in report.LazyPlayers)
                {
                    Console.WriteLine(player);
                }
            }
        }
    }
}
