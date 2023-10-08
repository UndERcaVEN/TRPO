using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeTraversal
{
    internal class TreeIO
    {
        private readonly BinaryTree<int> _tree;
        internal TreeIO()
        {
            _tree = new BinaryTree<int>();
        }
        internal void MainLoop()
        {
            while (true)
            {
                Console.Write("Press 1 to fill the tree, 2 to traverse it or q to quit");
                char input = Console.ReadKey(true).KeyChar;
                IOHelper.ClearCurrentConsoleLine();

                switch (input)
                {
                    case '1':
                        FillTree();
                        break;
                    case '2':
                        PrintTree();
                        break;
                    case 'q':
                        return;
                }

            }
        }

        private void FillTree()
        {
            bool inputParsed = int.TryParse(Console.ReadLine(), out int input);
            
            IOHelper.ClearCurrentConsoleLine();
            if (!inputParsed)
            {
                return;
            }
            _tree.AddElement(input);
        }

        private void PrintTree()
        {
            Console.WriteLine("Select traversal method:\n1 - Pre-order\n2 - in-order\n3 - post-order");
            string result;

            switch (Console.ReadKey(true).KeyChar)
            {
                case '1':
                    result = TreeTraversal.DepthFirstSearch(_tree); 
                    break;
                case '2':
                    result = TreeTraversal.SymmetricalSearch(_tree);
                    break;
                case '3':
                    result = TreeTraversal.PostOderSearch(_tree);
                    break;
                default:
                    return;
            }

            Console.WriteLine($"\nThe current array is: {result}");
        }
    }
}
