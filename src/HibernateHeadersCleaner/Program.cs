using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace HibernateHeadersCleaner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var ext = ".java";
            var contains = "// Generated";

            if (args.Length > 0)
            {
                ext = args[0];
            }

            if (args.Length > 1)
            {
                contains = args[1];
            }

            var info = new FileInfo(Assembly.GetExecutingAssembly().Location);

            Console.WriteLine("************ Started at " + DateTime.Now + " ************");
            Console.WriteLine("Processing {0}", info.Directory);

            foreach (
                var file in
                    Directory.GetFiles(info.DirectoryName, "*.*", SearchOption.AllDirectories)
                        .Where(s => s.EndsWith(ext)))
            {
                Console.Write("Cleaning file " + file);
                CleanLineInFile(file, contains);
                Console.WriteLine(" > Ok");
            }

            Console.WriteLine("************ Finished at " + DateTime.Now + " ************");
        }

        private static void CleanLineInFile(string file, string contains)
        {
            var tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(file))
            using (var sw = new StreamWriter(tempFile))
            {
                string line;

                var found = false;

                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains(contains) && !found)
                    {
                        found = true;
                        continue;
                    }

                    sw.WriteLine(line);
                }
            }

            File.Delete(file);
            File.Move(tempFile, file);
        }
    }
}