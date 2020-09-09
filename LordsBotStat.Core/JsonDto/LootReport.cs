namespace LordsBotStat.Core.JsonDto
{
    using System;

    using LordsBotStat.Core.Converters;

    using Newtonsoft.Json;

    /// <summary>
    /// The LootReport.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class LootReport
    {
        /// <summary>
        /// Gets or sets the guild detail.
        /// </summary>
        [JsonProperty("guildDetail")]
        public string GuildDetail { get; set; }

        /// <summary>
        /// Gets or sets the discard time.
        /// </summary>
        [JsonProperty("discardTime")]
        [JsonConverter(typeof(EpochConverter))]
        public DateTime DiscardTime { get; set; }

        /// <summary>
        /// Gets or sets the stat information.
        /// </summary>
        [JsonProperty("statInfo")]
        public StatInfo StatInfo { get; set; }

        /// <summary>
        /// Gets or sets the box data.
        /// </summary>
        [JsonProperty("boxData")]
        public BoxData[] BoxData { get; set; }
    }
}
