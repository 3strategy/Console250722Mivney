using NUnit.Framework;
using Unit4.CollectionsLib;
using static T22Mivney.BinNodeSolutions;
using T22Mivney;

namespace Tests3rdTry.BinNode
{
    internal class SumBinaryTreeNodes
    {
        [TestCase(new string[] { }, 0, TestName = "EmptyTree")]
        [TestCase(new[] {
            " 10 "
        }, 10, TestName = "RootOnly")]
        [TestCase(new[] {
            "     5     ",
            "  3     8  ",
            "1  4       "
        }, 21, TestName = "ComplexTree")]
        [TestCase(new[] {
            "    3    ",
            "         ",
            "  2      ",
            "         ",
            "1        "
        }, 6, TestName = "LeftSkewedTree")]
        [TestCase(new[] {
            "       10       ",
            "                ",
            "         20     ",
            "                ",
            "           30   "
        }, 60, TestName = "RightSkewedTree")]
[TestCase(new[] {
    "   10   ",
    "        ",
    " -2  7  "
}, 15, TestName = "TreeWithNegativeValues")]
        [TestCase(new[] {
            "   0   ",
            "       ",
            "-5  5  "
        }, 0, TestName = "TreeWithZero")]
        public void TestSumBinaryTreeNodes(string[] visualTree, int expectedSum)
        {
            BinNode<int> root = BuildTreeFromVisual(visualTree);
            int actualSum = BinNodeSolutions.SumBinaryTreeNodes(root);
            Assert.AreEqual(expectedSum, actualSum);
        }
    }
}
