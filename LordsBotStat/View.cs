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
        private static readonly LineThickness StrokeRight = new LineThickness(LineWidth.None, LineWidth.None, LineWidth.Single, LineWidth.None);

        /// <summary>
        /// Renders the specified report.
        /// </summary>
        /// <param name="report">The report.</param>
        /// <param name="plainText">if set to <c>true</c> [plain text].</param>
        public static void Render(Report report, bool plainText = false)
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
                                                      new Column { Width = GridLength.Auto }, // REQUIRED
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
                                                      new Cell("REQUIRED") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("STATUS") { Color = ConsoleColor.White, Align = Align.Center },
                                                      new Cell("DEBT") { Color = ConsoleColor.White, Align = Align.Center },
                                                      report.LazyPlayers.Select(
                                                          x => new []
                                                                   {
                                                                       // PLAYER
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Color = ConsoleColor.Yellow,
                                                                               Children = { x }
                                                                           },
                                                                       // LEVEL 2
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.DarkGray,
                                                                               Children = { 0 }
                                                                           },
                                                                       // LEVEL 3+
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.DarkGray,
                                                                               Children = { 0 }
                                                                           },
                                                                       // PAID
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.DarkGray,
                                                                               Children = { 0 }
                                                                           },
                                                                       // SCORE
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.Red,
                                                                               Children = { 0 }
                                                                           },
                                                                       // REQUIRED
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.Yellow,
                                                                               Children = { report.TotalScore }
                                                                           },
                                                                       // STATUS
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.Red,
                                                                               Children = { "BAD" }
                                                                           },
                                                                       // DEBT
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Children = { report.TotalScore }
                                                                           }
                                                                   }),
                                                      report.Items.OrderByDescending(x => x.Debt).Select(
                                                          x => new[]
                                                                   {
                                                                       // PLAYER
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Color = ConsoleColor.Yellow,
                                                                               Children = { x.PlayerName }
                                                                           },
                                                                       // LEVEL 2
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Lvl2 == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Lvl2 }
                                                                           },
                                                                       // LEVEL 3+
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Lvl3 == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Lvl3 }
                                                                           },
                                                                       // PAID
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Paid == 0 ? ConsoleColor.DarkGray : (ConsoleColor?) null,
                                                                               Children = { x.Paid }
                                                                           },
                                                                       // SCORE
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Score == 0 ? ConsoleColor.Red : (ConsoleColor?) null,
                                                                               Children = { x.Score }
                                                                           },
                                                                       // REQUIRED
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = ConsoleColor.Yellow,
                                                                               Children = { report.TotalScore }
                                                                           },
                                                                       // STATUS
                                                                       new Cell
                                                                           {
                                                                               Stroke = StrokeRight,
                                                                               Align = Align.Center,
                                                                               Color = x.Debt == 0 ? ConsoleColor.Green : ConsoleColor.Red,
                                                                               Children = { x.Status }
                                                                           },
                                                                       // DEBT
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

            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var renderRect = new Rect(0, 0, Console.WindowWidth - 1, Size.Infinity);

            var ts = report.DateTo - report.DateFrom;
            if (ts.HasValue)
            {
                Console.WriteLine("REPORT INTERVAL: {0:d} - {1:d} ({2} DAY(S)), MEMBERS: {3}",
                    report.DateFrom, report.DateTo?.AddDays(-1), ts.Value.Days,
                    report.Items.Count);
            }

            if (plainText)
            {
                var target = new TextRenderTarget();
                var s = ConsoleRenderer.RenderDocumentToText(doc, target, renderRect);
                Console.Write(s);
            }
            else
            {
                ConsoleRenderer.RenderDocument(doc, null, renderRect);
            }
        }
    }
}
