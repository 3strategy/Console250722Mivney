using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;

namespace T22Mivney
{
    public partial class BinNodeSolutions
    {
public static void JustADemo()
{
var root = BuildTreeFromVisual(new[] {
    "     5     ",
    "  3     8  ",
    "1  4       "
});
    TreeCanvas.AddTree(root);
}

        public static void JustAnOldDemo()
        {
            BinNode<int> root = new BinNode<int>(5);
            BinNode<int> leftChild = new BinNode<int>(3);
            BinNode<int> rightChild = new BinNode<int>(8);
            rightChild.SetLeft(new BinNode<int>(7));
            root.SetLeft(leftChild);
            root.SetRight(rightChild);
            TreeCanvas.AddTree(root);
        }

        /// <summary>
        /// 1. Sum the values in the tree elements
        /// </summary>
        /// <param name="binNode"></param>
        /// <returns></returns>
        public static int SumBinaryTreeNodes(BinNode<int> binNode)
        {
            if (binNode == null)
                return 0;
            return binNode.GetValue() + SumBinaryTreeNodes(binNode.GetLeft()) +
                SumBinaryTreeNodes(binNode.GetRight());
        }

    }
}
