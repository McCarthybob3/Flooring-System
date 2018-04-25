using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FlooringMastery.Data
{
    public class FilePathCheck
    {
        private static string _FilePath = FilePathSetting.FilePath;
        private static string _filePath;

        public static string Namecreator(DateTime Date)
        {

            string Converted = Date.ToString("MMddyyyy");
            string Name = "Orders_" + $"{Converted}.txt";
            return Name;
        }

        public static bool ValidateFile(DateTime date)
        {
            string Date = Namecreator(date);
            _filePath = $"{_FilePath}"+$"{Date}";

            if (File.Exists(_filePath))
            {
                return true;
            }
            else { return false; }

        }
    }
}
