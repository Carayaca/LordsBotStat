namespace LordsBotStat.Core.JsonDto
{
    using System.Diagnostics;
    using System.Text;

    using Newtonsoft.Json;

    /// <summary>
    /// The Item.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [DebuggerDisplay("{" + nameof(DebugString) + "}")]
    internal class Item
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        [JsonProperty("ItemID")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        [JsonProperty("Num")]
        public int Num { get; set; }

        /// <summary>
        /// Gets or sets the rank.
        /// </summary>
        [JsonProperty("ItemRank")]
        public int Rank { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [JsonProperty("ItemName")]
        public string Name { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugString
        {
            get
            {
                var sb = new StringBuilder();
                sb.Append(this.Name);
                if (this.Num > 1)
                {
                    sb.AppendFormat(" x{0}", this.Num);
                }

                return sb.ToString();
            }
        }
    }
}
