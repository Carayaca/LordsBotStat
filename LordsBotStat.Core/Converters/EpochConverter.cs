namespace LordsBotStat.Core.Converters
{
    using System;

    using Newtonsoft.Json;

    /// <summary>
    /// The epoch converter.
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
            return DateTimeOffset.FromUnixTimeSeconds((long)(reader?.Value ?? 0L)).UtcDateTime;
        }

        private static double ConvertToUnixTimestamp(DateTime date)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var diff = date.ToUniversalTime() - origin;
            return Math.Floor(diff.TotalSeconds);
        }
    }
}
