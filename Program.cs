using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System;
using System.IO;
using System.Text;

namespace pscgen
{
    public class Chapter
    {
        [Name("#")]
        public string MarkerId { get; set; }
        [Name("Name")]
        public string Name { get; set; }
        [Name("Start")]
        public string Start { get; set; }
        [Name("End")]
        public string End { get; set; }
        [Name("Length")]
        public string Length { get; set; }
        [Name("Color")]
        public string Color { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            var sourcePath = args[0];
            var targetPath = args[1];

            using (var reader = new StreamReader(sourcePath))
            using (var csv = new CsvReader(reader))
            {
               
                var records = csv.GetRecords<Chapter>();

                string output = String.Empty;

                output += "<? xml version=\"1.0\" encoding=\"utf-8\" ?>";
                output += Environment.NewLine;
                output += "<psc:chapters version=\"1.2\" xmlns:psc=\"http://podlove.org/simple-chapters\">";
                output += Environment.NewLine;

                foreach (var chapter in records)
                {
                    output += String.Concat("\t", "<psc:chapter start=\"" + chapter.Start + "\" title=\"" + chapter.Name + "\" />");
                    output += Environment.NewLine;
                }

                output += "</psc:chapters>";

                File.WriteAllText(targetPath, output, Encoding.UTF8);
            }
        }
    }
}
