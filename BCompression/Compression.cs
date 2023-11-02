using HuffmanCompression.FrequencyTable;
using HuffmanCompression.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuffmanCompression
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
