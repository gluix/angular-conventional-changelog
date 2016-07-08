using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LibGit2Sharp;
using System.Text.RegularExpressions;

namespace AngularConventionalChangelog
{
    public static class ChangelogBuilder
    {
        public static void Run(Options options)
        {
            var sbOut = new StringBuilder();
            using (var repo = new Repository(options.Repository))
            {
                var commitFilter = new CommitFilter();
                if (!string.IsNullOrEmpty(options.Since))
                    commitFilter.IncludeReachableFrom = options.Since;
                if (!string.IsNullOrEmpty(options.Until))
                    commitFilter.ExcludeReachableFrom = options.Until;

                var commitsGroups = from commit in repo.Commits.QueryBy(commitFilter) where CheckFilter(GetScope(commit), options.FilterScope) group commit by GetType(commit) into commitGroup select new { Type = commitGroup.Key, Commits = commitGroup.ToList() };
                foreach (var commitGroup in commitsGroups)
                {
                    if (CheckFilter(commitGroup.Type, options.FilterType))
                    {
                        sbOut.AppendLine("#" + commitGroup.Type);
                        foreach (var commit in commitGroup.Commits)
                        {
                            sbOut.AppendLine(GetMessage(commit));
                        }
                    }                    
                }
            }

            var outputPath = Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().CodeBase, options.OutputFile);
            File.WriteAllText(outputPath, sbOut.ToString());
        }

        private static bool CheckFilter(string value, IList<string> validValues)
        {
            return validValues.Contains("all") || validValues.Contains(value);
        }

        private static string GetType(Commit c)
        {
            var match = Regex.Match(c.Message, "([a-z]+)(\\(|:)");
            return match.Groups[1].Value;
        }

        private static string GetScope(Commit c)
        {
            var match = Regex.Match(c.Message, "\\(([a-z]*)\\)");
            return match.Groups[1].Value;
        }

        private static string GetMessage(Commit c)
        {
            var match = Regex.Match(c.Message, "\\:\\s*([\\s\\S]*)");
            return match.Groups[1].Value;
        }
    }
}
