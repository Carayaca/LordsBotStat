using System.Diagnostics;
using System.Reflection;

using NLog;

namespace LordsBotStat
{
    using System;
    using System.Collections.Generic;

    using CommandLine;
    using CommandLine.Text;

    using LordsBotStat.Core;

    /// <summary>
    /// The program.
    /// </summary>
    public static class Program
    {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();
        
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            try
            {
                var parser = new Parser(with => with.HelpWriter = null);
                var parserResult = parser.ParseArguments<ProgramOptions>(args);

                var r1 = parserResult.WithParsed(Run);
                parserResult.WithNotParsed(errs => DisplayHelp(r1, errs));
            }
            finally
            {
                LogManager.Shutdown();
            }
        }

        private static void Run(ProgramOptions options)
        {
            try
            {
                var report = JsonLoader.LoadDir(options.InputDirectory);
                if (!string.IsNullOrEmpty(options.Members))
                {
                    report.Imbue(options.Members);
                }

                View.Render(report, options.PlainText);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void DisplayHelp<T>(ParserResult<T> result, IEnumerable<Error> errs)
        {
            HelpText helpText;
            if (errs.IsVersion()) //check if error is version request
            {
                helpText = HelpText.AutoBuild(result);
            }
            else
            {
                helpText = HelpText.AutoBuild(result, h =>
                    {
                        h.AdditionalNewLineAfterOption = false;
                        h.AddDashesToOption = true;
                        return HelpText.DefaultParsingErrorsHandler(result, h);
                    }, e => e);
            }
            Console.WriteLine(helpText);
        }
    }
}
