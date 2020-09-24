namespace LordsBotStat.Core
{
    /// <summary>
    /// The Utils class.
    /// </summary>
    internal static class Utils
    {
        /// <summary>
        /// Select the <paramref name="@default" /> value if the <paramref name="self" /> is <see langword="null" /> or empty.
        /// </summary>
        /// <param name="self">The string.</param>
        /// <param name="default">The default value.</param>
        /// <returns>A <see cref="string"/>.</returns>
        public static string Or(this string self, string @default)
        {
            return string.IsNullOrEmpty(self) ? @default : self;
        }
    }
}
