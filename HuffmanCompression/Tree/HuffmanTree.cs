using HuffmanCompression.FrequencyTable;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HuffmanCompression.Tree
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
            if (Nodes.Count < 2) return;


            while(Nodes.Count > 1)
            {
                List<Node> nodes = Nodes.ToList();

                if(nodes.Count > 1)
                {
                    var selectedNodes = nodes.Take(2).ToList();
                    var node1 = selectedNodes[0];
                    var node2 = selectedNodes[1];

                    Node newNode = new Node(node1, node2, node1.Frequency + node2.Frequency);

                    Nodes.Remove(node1);
                    Nodes.Remove(node2);
                    Nodes.Add(newNode);
                }

                this.RootNode = Nodes.FirstOrDefault();
            }

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

        public int[] Encode(string input)
        {
            List<int> encodedData = new List<int>();
            Dictionary<char, List<int>> alreadyEncodedChars = new Dictionary<char, List<int>>();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = input[i];
                var HasBeenEncoded = alreadyEncodedChars.ContainsKey(currentChar);
                if(HasBeenEncoded)
                {
                    encodedData.AddRange(alreadyEncodedChars[currentChar]);

                }
                else
                {
                    var charEncoded = RootNode.Find(currentChar, new List<int>());
                    alreadyEncodedChars.Add(currentChar, charEncoded);
                    if (charEncoded != null) encodedData.AddRange(charEncoded);
                }
            }

            var result = encodedData.ToArray();

            return result;
        }

        public string Decode(int[] input)
        {
            StringBuilder sb = new StringBuilder();
            var currentNode = this.RootNode;

            for (int i = 0; i < input.Length; i++)
            {
                int currentVal = input[i];
                if (currentVal == 1)
                {
                    if(currentNode.Right != null)
                    {
                        currentNode = currentNode.Right;
                    }
                }

                if (currentVal == 0) 
                {
                    if(currentNode.Left != null) 
                    {
                        currentNode = currentNode.Left;
                    }
                }

                if(currentNode.IsLeaf)
                {
                    sb.Append(currentNode.Character);
                    currentNode = this.RootNode;
                }
            }

            return sb.ToString();
        }

        private void OrderNodes()
        {
            if(Nodes.Count > 1) Nodes = Nodes.OrderBy(x => x.Frequency).ToList();

        }
    }
}
