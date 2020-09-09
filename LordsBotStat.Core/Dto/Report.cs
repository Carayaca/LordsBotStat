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
        public IReadOnlyCollection<string> LazyPlayers { get; set; } = new string[0];

        /// <summary>
        /// Imbue the additional guild information.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        public void Imbue(string fileName)
        {
            try
            {
                var members = new GuildLoader().LoadMembersList(fileName);
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
