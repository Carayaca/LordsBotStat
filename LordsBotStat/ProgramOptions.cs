using System.Diagnostics.CodeAnalysis;

using JetBrains.Annotations;

namespace LordsBotStat
{
    using CommandLine;

    using LordsBotStat.Core;

    /// <summary>
    /// The ProgramOptions.
    /// </summary>
    [UsedImplicitly]
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public class ProgramOptions : IProgramOptions
    {
        /// <inheritdoc />
        [Option('M', "members"
            , HelpText = "The path to xlsx file with guild members"
            , Required = false
        )]
        public string Members { get; set; }

        /// <inheritdoc />
        [Value(0
            , Required = true
            , MetaName = "InputDirectory"
            , HelpText = "Input directory with JSON reports")]
        public string InputDirectory { get; set; }

        /// <inheritdoc />
        [Option("plain-text"
            , HelpText = "The report should be rendered in a plain text"
            , Required = false
        )]
        public bool PlainText { get; set; }
    }
}
