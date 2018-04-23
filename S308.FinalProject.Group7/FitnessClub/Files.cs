using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessClub
{
    class Files
    {
        public string strFilePath { get; set; }
        public string strTimeStamp { get; set; }
        public string strExtension { get; set; }

        public Files()
        {

        }

        public Files(string FilePath, string TimeStamp, string Extension)
        {
            strFilePath = FilePath;
            strTimeStamp = TimeStamp;
            strExtension = Extension;
        }

        public string GetFilePath(string filepath, string ex, bool withTimeStamp)
        {
            if (withTimeStamp)
            {
                filepath += "_" + withTimeStamp;
            }
            filepath += "." + ex;
            return filepath;
        }
        
    }
}
