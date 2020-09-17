using System.IO;
using System.Text;

using Newtonsoft.Json;

namespace LordsBotStat.Core
{
    /// <summary>
    /// The Json utilities class.
    /// </summary>
    internal static class Json
    {
        /// <summary>
        /// Loads the json.
        /// </summary>
        /// <typeparam name="T">Data type.</typeparam>
        /// <param name="fileName">Name of the file.</param>
        /// <returns><typeparamref name="T"/>.</returns>
        public static T LoadFrom<T>(string fileName)
        {
            using (var fs = File.OpenRead(fileName))
            using (var sr = new StreamReader(fs, Encoding.UTF8))
            using (var jsonTextReader = new JsonTextReader(sr))
            {
                var serializer = new JsonSerializer();
                var json = serializer.Deserialize<T>(jsonTextReader);
                return json;
            }
        }
    }
}
