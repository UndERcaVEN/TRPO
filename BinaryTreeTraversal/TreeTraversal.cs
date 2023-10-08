using System.Text;

namespace BinaryTreeTraversal
{
    public static class TreeTraversal
    {
        public static string DepthFirstSearch<T>(BinaryTree<T> tree)
        {
            var result = new StringBuilder();

            AppendPreOrder(tree, 0, result);
            return result.ToString();
        }

        public static string SymmetricalSearch<T>(BinaryTree<T> tree)
        {
            var result = new StringBuilder();

            AppendSymmetrical(tree, 0, result);
            return result.ToString();
        }


        public static string PostOderSearch<T>(BinaryTree<T> tree)
        {
            var result = new StringBuilder();

            AppendPostOrder(tree, 0, result);
            return result.ToString();
        }

        private static void AppendSymmetrical<T>(BinaryTree<T> tree, int index, StringBuilder result)
        {
            if (index >= tree.ElementsCount)
            {
                return;
            }

            int leftIndex = index * 2 + 1;
            AppendSymmetrical(tree, leftIndex, result);

            result.Append(" " + tree.ElementAt(index));

            int rightIndex = index * 2 + 2;
            AppendSymmetrical(tree, rightIndex, result);
        }

        private static void AppendPreOrder<T>(BinaryTree<T> tree, int index, StringBuilder result)
        {
            if (index >= tree.ElementsCount)
            {
                return;
            }

            result.Append(" " + tree.ElementAt(index).ToString());

            int leftIndex = index * 2 + 1;
            AppendPreOrder(tree, leftIndex, result);

            int rightIndex = index * 2 + 2;
            AppendPreOrder(tree, rightIndex, result);
        }

        private static void AppendPostOrder<T>(BinaryTree<T> tree, int index, StringBuilder result)
        {
            if (index >= tree.ElementsCount)
            {
                return;
            }

            int leftIndex = index * 2 + 1;
            AppendPostOrder(tree, leftIndex, result);

            int rightIndex = index * 2 + 2;
            AppendPostOrder(tree, rightIndex, result);

            result.Append(" " + tree.ElementAt(index).ToString());
        }
    }
}
