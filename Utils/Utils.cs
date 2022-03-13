using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffManagement
{
    public static class Utils
    {
        public static string ppPath;
        public static string photoFolderPath;

        static Utils()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            ppPath = Path.GetFullPath(Path.Combine(baseDir, @"..\..\"));
            photoFolderPath = Path.Combine(ppPath, @"res\photo");
        }

        public static Image getImageFromFileName(string filename)
        {
            if (filename == null || filename.Length == 0)
            {
                return null;
            }
            string imgFilePath = string.Format("{0}res\\photo\\{1}", ppPath, filename);
            return new Bitmap(imgFilePath);
        }

        public static int getDays(int month, int year)
        {
            switch (month)
            {
                case 1: case 3: case 5: case 7: case 8: case 10: case 12:
                    return 31;
                case 2:
                    if (year % 4 == 0 && year % 100 != 0 || year % 400 == 0) return 29;
                    else return 28;
                default:
                    return 30;
            }
        }
    }
}
