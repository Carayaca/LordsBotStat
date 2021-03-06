﻿namespace LordsBotStat.Core.JsonDto
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Text.RegularExpressions;

    using LordsBotStat.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    /// The BoxData.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    [DebuggerDisplay("{" + nameof(DebugString) + "}")]
    internal class BoxData
    {
        private static readonly Regex RxMonsterLoot = new Regex(@"\[\w+\] (?<Name>[\w\s]+) Loot", RegexOptions.Compiled);

        /// <summary>
        /// Gets or sets the sequence.
        /// </summary>
        [JsonProperty("SN")]
        public int Sequence { get; private set; }

        /// <summary>
        /// Gets or sets the status.
        /// </summary>
        [JsonProperty("Status")]
        public int Status { get; set; }

        /// <summary>
        /// Gets or sets the RCV time.
        /// </summary>
        [JsonProperty("RcvTime")]
        [JsonConverter(typeof(EpochConverter))]
        public DateTime RcvTime { get; set; }

        /// <summary>
        /// Gets the box item identifier.
        /// </summary>
        [JsonProperty("BoxItemID")]

        public int BoxItemId { get; private set; }

        /// <summary>
        /// Gets or sets the name of the player.
        /// </summary>
        [JsonProperty("PlayerName")]
        public string PlayerName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this box is purchase.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this box is purchase; otherwise, <c>false</c>.
        /// </value>
        [JsonProperty("isPurchase")]
        public bool IsPurchase { get; set; }

        /// <summary>
        /// Gets or sets the box level.
        /// </summary>
        [JsonProperty("boxLevel")]
        public int BoxLevel { get; set; }

        /// <summary>
        /// Gets or sets the name of the box.
        /// </summary>
        [JsonProperty("boxName")]
        public string BoxName { get; set; }

        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        [JsonProperty("Item")]
        public Item Item { get; set; }

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebugString
        {
            get
            {
                var sb = new StringBuilder();
                sb.AppendFormat("{0}, ", string.IsNullOrEmpty(this.PlayerName) ? "<Аноним>" : this.PlayerName);

                if (this.IsPurchase)
                {
                    sb.AppendFormat("{0}", this.BoxName);
                }
                else
                {
                    var m = RxMonsterLoot.Match(this.BoxName);
                    sb.AppendFormat("{0}", m.Success ? m.Groups["Name"].Value : this.BoxName);
                }

                sb.Append(", ");
                sb.AppendFormat("LV {0}", this.BoxLevel);

                return sb.ToString();
            }
        }
    }
}
