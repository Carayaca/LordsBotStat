namespace LordsBotStat.Core.Dto
{
    /// <summary>
    /// The RenderItem class.
    /// </summary>
    public class RenderItem
    {
        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Boxes 2 LEVEL.
        /// </summary>
        public int Lvl2 { get; set; }

        /// <summary>
        /// Boxes 3+ LEVEL.
        /// </summary>
        public int Lvl3 { get; set; }

        /// <summary>
        /// Paid boxes.
        /// </summary>
        public int Paid { get; set; }

        /// <summary>
        /// Gets or sets the score.
        /// </summary>
        public int Score => this.Lvl2 * 2 + this.Lvl3 * 6;

        /// <summary>
        /// Gets the status.
        /// </summary>
        public string Status => this.Debt == 0 ? "GOOD" : "BAD";

        /// <summary>
        /// Gets the debt.
        /// </summary>
        public int Debt
        {
            get
            {
                if (this.Score >= 14)
                {
                    return 0;
                }

                return 14 - this.Score;
            }
        }
    }
}
