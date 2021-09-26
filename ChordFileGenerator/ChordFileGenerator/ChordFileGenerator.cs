using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace ChordFileGenerator
{
    public class ChordFileGenerator
    {
        public string SongName { get; set; }
        public string Artist { get; set; }
        public FileType FileType { get; set; }
        private List<string> lines;

        public ChordFileGenerator()
        {
            lines = new List<string>();
        }

        public void AddLine(string chords, string lyrics)
        {
            AddLine(chords);
            AddLine(lyrics);
        }
        public void AddLine(string lyrics)
        {
            lines.Add(lyrics);
        }

        public void SaveFile(string fileName)
        {
            string Info = GenerateFileContents();
            File.WriteAllText(fileName, Info);
        }

        private string GenerateFileContents()
        {
            StringBuilder contents = new StringBuilder();

            contents.AppendLine("Song Name: " + SongName);
            contents.AppendLine("Artist: " + Artist);

            switch (FileType)
            {
                case FileType.Chords:
                    contents.AppendLine("Type: Chords");
                    break;
                case FileType.Tab:
                    contents.AppendLine("Type: Tab");
                    break;
                default:
                    contents.AppendLine("Type: Lyrics");
                    break;
            }

            contents.AppendLine("***************************************************");

            foreach (string line in lines)
            {
                contents.AppendLine(line);
            }

            return contents.ToString();
        }


    }

    public enum FileType
    {
        Chords, Tab, Lyrics
    }
}
