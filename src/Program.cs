using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularConventionalChangelog
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new Options();
            if (CommandLine.Parser.Default.ParseArguments(args, options))
            {
                Console.WriteLine("In: {0}", options.Repository);
                Console.WriteLine("Out: {0}", options.OutputFile);
                ChangelogBuilder.Run(options);
                Console.WriteLine("Done");
            }
            Console.ReadKey();
        }
    }
}
