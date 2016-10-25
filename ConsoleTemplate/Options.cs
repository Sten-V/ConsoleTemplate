using CommandLine;

namespace ConsoleTemplate
{
    class Options
    {
        [Option('p', "path", Default = @"C:\temp", HelpText = "Path description")]
        public string TestPath { get; set; }
    }
}
