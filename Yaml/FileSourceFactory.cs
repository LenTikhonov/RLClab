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
        public IFileSource Create(string path, GoodsFactory goodsFactory)
        {
            string extention = Path.GetExtension(path);
            switch (extention)
            {
                case ".yaml":
                    return new YamlFileSource(goodsFactory);
                case ".txt":
                    return new TxtFileSource(goodsFactory);
            }
            return null;
        }
    }
}
