using System.Linq.Expressions;

namespace HuffmanCompression.Tree
{
    internal class Node
    {
        public char Character { get; set; }
        public int Frequency { get; set; }
        public bool IsLeaf { get { return Left == null && Right == null; } }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(char character,int frequency) 
        {
            Character = character;
            Frequency = frequency;
        }

        public Node(Node left, Node right, int frequency)
        {
            Left = left;
            Right = right;
            Frequency = frequency;
        }

        public List<int> Find(char character, List<int> data)
        {
            if(IsLeaf)
            {
                if(character.Equals(Character))
                {
                    return data;
                }
                else 
                {
                    return null;
                }
            }
            else
            {
                if (Left != null)
                {
                    List<int> leftData = data.ToList();
                    leftData.Add(0);
                    var traverseResult = Left.Find(character, leftData);
                    if(traverseResult != null) 
                    {
                        return traverseResult;
                    }
                }

                if (Right != null)
                {
                    List<int> rightData = data.ToList();
                    rightData.Add(1);
                    var traverseResult = Right.Find(character, rightData);
                    if (traverseResult != null)
                    {
                        return traverseResult;
                    }
                }

                return null;
            }
        }
    }
}
