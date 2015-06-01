using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunNUnitTests
{
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];

            var files = Directory.GetFiles(path);

            NUnitMerger.MergeFiles(files, args[1]);
        }
    }
}
