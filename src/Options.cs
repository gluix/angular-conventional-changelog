using System.Collections.Generic;
using CommandLine;
using CommandLine.Text;

namespace AngularConventionalChangelog
{
    public class Options
    {
        [Option('o', "out", Required = true, HelpText = "Path to the output-file.")]
        public string OutputFile { get; set; }

        [Option('r', "repository", Required = true, HelpText = "Path to the git repository to process.")]
        public string Repository { get; set; }

        [OptionList('t', "filter-type", DefaultValue = new[] {"all"}, Separator = ':', HelpText = "Filter commits by type(s).")]
        public IList<string> FilterType { get; set; }

        [OptionList('s', "filter-scope", DefaultValue = new[] { "all" }, Separator = ':', HelpText = "Filter commits by scope(s).")]
        public IList<string> FilterScope { get; set; }

        [Option("since", Required = false, HelpText = "A pointer to a commit object or a list of pointers to consider as starting points.")]
        public string Since { get; set; }

        [Option("until", Required = false, HelpText = "A pointer to a commit object or a list of pointers which will be excluded (along with ancestors) from the enumeration.")]
        public string Until { get; set; }

        [ParserState]
        public IParserState LastParserState { get; set; }

        [HelpOption]
        public string GetUsage()
        {
            return HelpText.AutoBuild(this,
              (HelpText current) => HelpText.DefaultParsingErrorsHandler(this, current));
        }
    }
}
