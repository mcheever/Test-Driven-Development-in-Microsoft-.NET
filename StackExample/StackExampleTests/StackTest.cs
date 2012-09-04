using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StackExample;

namespace StackExampleTests
{
    [TestClass]
    public class StackTest
    {
        private Stack stack;

        [TestInitialize]
        public void Init()
        {
            stack = new Stack();
        }

        [TestMethod]
        public void Empty()
        {
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void PushOne()
        {
            stack.Push("first element");
            Assert.IsFalse(stack.IsEmpty, "After Push, IsEmpty should be false");
        }

        [TestMethod]
        public void Pop()
        {
            stack.Push("first element");
            stack.Pop();
            Assert.IsTrue(stack.IsEmpty, "After Push - Pop, IsEmpty should be true");
        }

        [TestMethod]
        public void PushPopContentTest()
        {
            int expected = 1234;
            stack.Push(expected);
            int actual = (int)stack.Pop();
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void PushPopMultipleElements()
        {
            string pushed1 = "1";
            stack.Push(pushed1);
            string pushed2 = "2";
            stack.Push(pushed2);
            string pushed3 = "3";
            stack.Push(pushed3);

            string popped = (string)stack.Pop();
            Assert.AreEqual(pushed3, popped);
            popped = (string)stack.Pop();
            Assert.AreEqual(pushed2, popped);
            popped = (string)stack.Pop();
            Assert.AreEqual(pushed1, popped);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PopEmptyStack()
        {
            stack.Pop();
        }

        [TestMethod]
        public void PushTop()
        {
            stack.Push("42");
            stack.Top();
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void PushTopContectCheckOneElement()
        {
            string pushed = "42";
            stack.Push(pushed);
            string topped = (string)stack.Top();
            Assert.AreEqual(pushed, topped);
        }

        [TestMethod]
        public void PushTopContentCheckMultiples()
        {
            string pushed3 = "3";
            stack.Push(pushed3);
            string pushed4 = "4";
            stack.Push(pushed4);
            string pushed5 = "5";
            stack.Push(pushed5);
            string topped = (string)stack.Top();
            Assert.AreEqual(pushed5, topped);
        }

        [TestMethod]
        public void PushTopNoStackStateChange()
        {
            string pushed = "44";
            stack.Push(pushed);

            for (int index = 0; index < 10; index++)
            {
                string topped = (string)stack.Top();
                Assert.AreEqual(pushed, topped);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TopEmptyStack()
        {
            stack.Top();
        }

        [TestMethod]
        public void PushNull()
        {
            stack.Push(null);
            Assert.IsFalse(stack.IsEmpty);
        }

        [TestMethod]
        public void PushNullCheckPop()
        {
            stack.Push(null);
            Assert.IsNull(stack.Pop());
            Assert.IsTrue(stack.IsEmpty);
        }

        [TestMethod]
        public void PushNullCheckTop()
        {
            stack.Push(null);
            Assert.IsNull(stack.Top());
            Assert.IsFalse(stack.IsEmpty);
        }
    }
}
