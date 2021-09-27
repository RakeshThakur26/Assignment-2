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


    public void SaveFile(string file)
    {
            StringBuilder contents = new StringBuilder();
            string dir = Directory.GetCurrentDirectory();
            FileStream fs = new FileStream(dir + "\\" + file, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);

            sr.WriteLine("Song Name: " + SongName);
            sr.WriteLine("Artist: " + Artist);

            switch (FileType)
            {
                case FileType.Chords:
                    sr.WriteLine("Type: Chords");
                    break;
                case FileType.Tab:
                    sr.WriteLine("Type: Tab");
                    break;
                default:
                    sr.WriteLine("Type: Lyrics");
                    break;
            }
            sr.WriteLine("Lyrics : ");
            foreach (var item in lines)
            {
                sr.WriteLine(item);
            }
            sr.WriteLine("***************************************************");
            sr.Close();
            fs.Close();
            Console.WriteLine("Saved successfully..!");

        }

        public void GetSongDetails()
        {
            Console.WriteLine("The Song details....!");
        }

    }

    public enum FileType
    {
        Chords, Tab, Lyrics
    }
}
