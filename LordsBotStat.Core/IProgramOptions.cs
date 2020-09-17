namespace LordsBotStat.Core
{
    /// <summary>
    /// The ProgramOptions interface.
    /// </summary>
    public interface IProgramOptions
    {
        /// <summary>
        /// Gets or sets the members file.
        /// </summary>
        string Members { get; }

        /// <summary>
        /// Gets or sets the input directory.
        /// </summary>
        string InputDirectory { get; }

        /// <summary>
        /// Gets a value indicating whether [plain text].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [plain text]; otherwise, <c>false</c>.
        /// </value>
        bool PlainText { get; }
    }
}
