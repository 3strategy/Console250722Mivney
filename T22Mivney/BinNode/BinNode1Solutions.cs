using Unit4.CollectionsLib;
using Unit4.BinTreeCanvasLib;

namespace T22Mivney
{
    public class BinNode1Solutions
    {

        public static void JustADemo()
        {
            BinNode<int> root = new BinNode<int>(5);
            BinNode<int> leftChild = new BinNode<int>(3);
            BinNode<int> rightChild = new BinNode<int>(8);
            rightChild.SetLeft(new BinNode<int>(7));
            root.SetLeft(leftChild);
            root.SetRight(rightChild);
            TreeCanvas.AddTree(root);
        }
    }
}
