namespace BCompression.FrequencyTable
{
    internal sealed class FrequencyTable
    {
        /// <summary>
        /// Key = Character, Value = Number of Occurrences
        /// </summary>
        private Dictionary<char,int> _frequencyTable = new Dictionary<char,int>();

        public Dictionary<char,int> Table => _frequencyTable;

        private void AddToTable(char c)
        {
            if (_frequencyTable.ContainsKey(c))
            {
                _frequencyTable[c]++;
            }
            else 
            {
                _frequencyTable.Add(c, 1);
            }
        }

        private void Compute(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                AddToTable(input[i]);
            }
        }

        public static FrequencyTable Build(string input)
        {
            FrequencyTable frequencyTable = new FrequencyTable();

            frequencyTable.Compute(input);

            return frequencyTable;
        }
    }
}
