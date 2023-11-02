using System.Collections;

namespace HuffmanCompression.Helpers
{
    internal class FileHelper
    {
        public static void WriteIntArrayToFile(string filePath, int[] intArray)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.Write(intArray);
            }
        }

        public static string RemoveExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }
    }
}
