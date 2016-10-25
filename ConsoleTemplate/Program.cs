using System;
using System.Collections.Generic;
using CommandLine;
using log4net;
using log4net.Config;

namespace ConsoleTemplate
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program));
        private static Options _options;

        static void Main(string[] args)
        {
            XmlConfigurator.Configure();
            Log.Info("Start");

            try
            {
                RunProgram(args);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

            Log.Info("Exit");
        }

        private static void RunProgram(string[] args)
        {
            if (!Initialize(args))
            {
                return;
            }

            RunProgram();
        }

        private static void RunProgram()
        {
            Console.WriteLine(_options.TestPath);
        }

        private static bool Initialize(IEnumerable<string> args)
        {
            _options = ParseArguments(args);

            if (_options == null)
            {
                Log.Error("Error during initialization");
                return false;
            }

            return true;
        }

        private static Options ParseArguments(IEnumerable<string> args)
        {
            Options result = null;

            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(x => result = x);

            return result;
        }
    }
}
