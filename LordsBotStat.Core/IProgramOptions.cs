namespace LordsBotStat.Core
{
    /// <summary>
    /// The ProgramOptions interface.
    /// </summary>
    public interface IProgramOptions
    {
        /// <summary>
        /// Gets or sets the members.
        /// </summary>
        string Members { get; set; }

        /// <summary>
        /// Gets or sets the input directory.
        /// </summary>
        string InputDirectory { get; set; }
    }
}
