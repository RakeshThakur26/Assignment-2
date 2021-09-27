using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace SongDeatails
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo file = new FileInfo(@"C:\Training\Assignment-2\ChordFileGenerator\ChordFileGenerator\bin\Debug\ChordFileGenerator.dll");
            Assembly assembly = Assembly.LoadFrom(file.FullName);

            Type type = assembly.GetType("ChordFileGenerator.ChordFileGenerator");

            object obj = Activator.CreateInstance(type);

            Console.Write("Enter Song Name : ");
            string songName = Console.ReadLine();
            PropertyInfo property = obj.GetType().GetProperty("SongName");
            property.SetValue(obj, songName);

            Console.Write("Enter Artist of the entered Song : ");
            string artist = Console.ReadLine();
            property = obj.GetType().GetProperty("Artist");
            property.SetValue(obj, artist);

            Console.Write("Enter File Type : ");
            string fileType = Console.ReadLine();

            Type EnumTypes = assembly.GetType("ChordFileGenerator.FileType");

            object fileTypeValue = GetEnumValue(EnumTypes, fileType);
            property = obj.GetType().GetProperty("FileType");
            property.SetValue(obj, fileTypeValue);
            

            int choice;
            int ch = 1;
            do
            {
                Console.Write("Choose Line Type option :\n1. Lyric(L) \n2. Chords and Lyric (CL) : ");
                choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.WriteLine("Enter Lyrics : ");
                    string lyrics = Console.ReadLine();
                    MethodInfo addLine = type.GetMethod("SaveFile");
                    addLine.Invoke(obj, new object[] { lyrics });
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter Chords : ");
                    string chords = Console.ReadLine();

                    Console.WriteLine("Enter Lyrics : ");
                    string lyrics = Console.ReadLine();

                    MethodInfo addLine = type.GetMethod("SaveFile");
                    addLine.Invoke(obj, new object[] { chords, lyrics });                 
                }
                Console.WriteLine("Do you want to continue ? Enter 1 to continue 0 to skip: ");
                ch = Convert.ToInt32(Console.ReadLine());
            } while (ch == 1);

            MethodInfo method = type.GetMethod("SaveFile");
            method.Invoke(obj, new object[] { "test.txt" });

            Console.ReadLine();
        }

        public static object GetEnumValue(Type enumType, string enumItemName)
        {
            Type enumUnderlyingType = enumType.GetEnumUnderlyingType();
            List<string> enumNames = enumType.GetEnumNames().ToList();

            Array enumValues = enumType.GetEnumValues();

            object enumValue = enumValues.GetValue(enumNames.IndexOf(enumItemName));

            return Convert.ChangeType(enumValue, enumUnderlyingType);
        }
    }
}


