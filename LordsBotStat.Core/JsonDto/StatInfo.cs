namespace LordsBotStat.Core.JsonDto
{
    using Newtonsoft.Json;

    /// <summary>
    /// The StatInfo.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    internal class StatInfo
    {
        /// <summary>
        /// Gets or sets the help sent.
        /// </summary>
        [JsonProperty("helpSent")]
        public int HelpSent { get; set; }

        /// <summary>
        /// Gets or sets the gifts collected total.
        /// </summary>
        [JsonProperty("giftsCollectedTotal")]
        public int GiftsCollectedTotal { get; set; }

        /// <summary>
        /// Gets or sets the gifts collected.
        /// </summary>
        [JsonProperty("giftsCollected")]
        public int[] GiftsCollected { get; set; }
    }
}
