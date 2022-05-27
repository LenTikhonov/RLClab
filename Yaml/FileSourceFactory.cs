using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RLClab
{
    public class FileSourceFactory
    {
        public IFileSource Create(string path)
        {
            string extention = Path.GetExtension(path);
            switch (extention)
            {
                case ".yaml":
                    return new YamlFileSource();
                case ".txt":
                    return new TxtFileSource();
            }
            return null;
        }
    }
}