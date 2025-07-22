using NUnit.Framework;
using Unit4.CollectionsLib;
using static T22Mivney.NodeSolutions;
//private GPT https://chatgpt.com/c/687fc9ac-fd10-8333-85f0-98941e31672b
//public GPT https://chatgpt.com/share/687fcb71-ee74-800e-8cf4-8f5ecca3f73c

namespace UnitTests
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            // Initialization before each test if needed
        }

        [Test]
        public void RemoveObjAny_RemovesAllInstances_WhenObjectIsPresent()
        {
            // Arrange
            var list = BuildIntListFromString("5,5,5,4,5");

            // Act
            var result = RemoveObjAny(list, 5);

            // Assert
            Assert.That(NodeToString(result), Is.EqualTo("4"));
        }

        [Test]
        public void RemoveObjAny_ReturnsOriginal_WhenObjectNotPresent()
        {
            // Arrange
            var list = BuildIntListFromString("1,2,3,4");

            // Act
            var result = RemoveObjAny(list, 5);
            string resStr = NodeToString(result);
            // Assert
            Assert.That(resStr, Is.EqualTo("1 ⟶ 2 ⟶ 3 ⟶ 4"));
        }

        [Test]
        public void RemoveObjAny_RemovesMiddleInstances_OnlyLeavesOthers()
        {
            // Arrange
            var list = BuildIntListFromString("1,2,3,2,4");

            // Act
            var result = RemoveObjAny(list, 2);

            // Assert
            Assert.That(NodeToString(result), Is.EqualTo("1 ⟶ 3 ⟶ 4"));
        }

        [Test]
        public void RemoveObjAny_HandlesEmptyList_Gracefully()
        {
            // Arrange
            Node<int> list = null;

            // Act
            var result = RemoveObjAny(list, 1);

            // Assert
            Assert.That(result, Is.Null);
        }

        [Test]
        public void RemoveSequencesOfIdenticalNumbers_RemovesConsecutiveDuplicates()
        {
            // Arrange
            var list = BuildIntListFromString("4,4,-5,-5,-5,8,8,4,6,-5,7,8,8,8,8,8,9");

            // Act
            RemoveSequencesOfIdenticalNumbers(list);
            string resStr = NodeToString(list);
            // Assert
            Assert.That(
                resStr,
                Is.EqualTo("4 ⟶ -5 ⟶ 8 ⟶ 4 ⟶ 6 ⟶ -5 ⟶ 7 ⟶ 8 ⟶ 9")
            );
        }

        [Test]
        public void RemoveSequencesOfIdenticalNumbers_LeavesSingleElementList_Unchanged()
        {
            // Arrange
            var list = BuildIntListFromString("7");

            // Act
            RemoveSequencesOfIdenticalNumbers(list);

            // Assert
            Assert.That(NodeToString(list), Is.EqualTo("7"));
        }

        [Test]
        public void RemoveSequencesOfIdenticalNumbers_NoSequences_NoChange()
        {
            // Arrange
            var list = BuildIntListFromString("1,2,3,2,1");

            // Act
            RemoveSequencesOfIdenticalNumbers(list);

            // Assert
            Assert.That(NodeToString(list), Is.EqualTo("1 ⟶ 2 ⟶ 3 ⟶ 2 ⟶ 1"));
        }
    }
}
