namespace LordsBotStat.Core.Converters
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The epoch time converter to/from <see cref="DateTime"/>.
    /// </summary>
    /// <seealso cref="JsonConverter{DateTime}" />
    internal class EpochConverter : JsonConverter<DateTime>
    {
        /// <inheritdoc />
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(ConvertToUnixTimestamp(value));
        }

        /// <inheritdoc />
        public override DateTime ReadJson(
            JsonReader reader,
            Type objectType,
            DateTime existingValue,
            bool hasExistingValue,
            JsonSerializer serializer)
        {
            return DateTimeOffset.FromUnixTimeSeconds((long)(reader?.Value ?? 0L)).LocalDateTime;
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
