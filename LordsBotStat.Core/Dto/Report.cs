namespace LordsBotStat.Core.Dto
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// The Report class.
    /// </summary>
    public class Report
    {
        private const int ScorePerDay = 14;

        /// <summary>
        /// Gets or sets date from.
        /// </summary>
        public DateTime? DateFrom { get; set; }

        /// <summary>
        /// Gets or sets date to.
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Gets or sets the total boxes.
        /// </summary>
        public int TotalBoxes { get; set; }

        /// <summary>
        /// Gets or sets the players count.
        /// </summary>
        public int PlayersCount { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        public IReadOnlyCollection<RenderItem> Items { get; set; } = new RenderItem[0];

        /// <summary>
        /// Gets or sets the lazy players.
        /// </summary>
        public IReadOnlyCollection<string> LazyPlayers { get; private set; } = new string[0];

        /// <summary>
        /// Gets the total score for the full period.
        /// </summary>
        public int TotalScore
        {
            get
            {
                var ts = this.DateTo - this.DateFrom;
                return ts.GetValueOrDefault().Days * ScorePerDay;
            }
        }

        /// <summary>
        /// Imbue the additional guild information.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void Imbue(string fileName)
        {
            try
            {
                var members = GuildLoader.LoadMembersList(fileName);
                this.LazyPlayers = members.Except(this.Items.Select(item => item.PlayerName))
                    .ToList();
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
