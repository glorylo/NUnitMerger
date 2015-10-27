using System;
using System.IO;

namespace NUnitResultMerger
{
    enum ExitCode
    {
        Success = 0,
        Error = 1,
        MissingArguments = 2
    }

    class Program
    {
        static int Main(string[] args)
        {

            if (args.Length != 3)
            {
                Console.WriteLine(@"NUnitResultMerger <source_dir> <filter> <output_file>");
                Console.WriteLine(@"Example:  NUnitResultMerger \path\to\dir *.xml \path\to\output.xml");
                return (int) ExitCode.MissingArguments;
            }

            var path = args[0];
            var searchPattern = args[1];
            var output = args[2];

            try
            {
                var files = Directory.GetFiles(path, searchPattern);

                if (files.Length < 2)
                {
                    Console.WriteLine(@"Unable to find at least 2 files to merge.  Exiting");
                    return (int) ExitCode.Error;
                }
                NUnitResultMerger.MergeFiles(files, output);
            }            
            catch(Exception e)
            {
                Console.WriteLine(@"Unexpected fail to merge report:  " + e.Message);
                return (int)ExitCode.Error;
            }
            Console.WriteLine(@"Merge completed successfully.  Created " + output);
            return (int) ExitCode.Success;
        }
    }
}
