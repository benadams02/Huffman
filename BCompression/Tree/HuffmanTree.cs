using BCompression.FrequencyTable;

namespace BCompression.Tree
{
    internal class HuffmanTree
    {
        public Node RootNode { get; set; }
        public List<Node> Nodes { get; set; } = new List<Node>();
        public FrequencyTable.FrequencyTable FrequencyTable { get; set; }

        public HuffmanTree(FrequencyTable.FrequencyTable frequencyTable)
        {
            FrequencyTable = frequencyTable;
            BuildNodes();
            BuildTree();
        }

        private void BuildTree()
        {
            this.RootNode = Nodes.FirstOrDefault();

            if (Nodes.Count < 2) return;


        }

        private void BuildNodes()
        {
            Nodes.Clear();

            foreach ( var kvp in FrequencyTable.Table ) 
            {
                var node = new Node(kvp.Key, kvp.Value);
                Nodes.Add(node);
            }
            
            OrderNodes();
        }

        private void OrderNodes()
        {
            if(Nodes.Count > 1) Nodes = Nodes.OrderBy(x => x.Frequency).ToList();

        }
    }
}
