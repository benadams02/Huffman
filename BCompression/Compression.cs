using BCompression.FrequencyTable;
using BCompression.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCompression
{
    public class Compression
    {
        public Compression() 
        {
            
        }

        public void Compress(string filePath)
        { 
            if(!File.Exists(filePath)) throw new FileNotFoundException();

            var fileText = File.ReadAllText(filePath);

            var frequencyTable = FrequencyTable.FrequencyTable.Build(fileText);

            var huffmanTree = new HuffmanTree(frequencyTable);
        }

        public void Decompress()
        {

        }
    }
}
