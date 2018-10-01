using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NonEmptyList;

namespace NonEmptyList_Tests
{
    [TestClass]
    public class NonEmptyListSpec
    {
        private int _head;
        private List<int> _tail;
        private NonEmptyList<int> _noTail;
        private NonEmptyList<int> _withTail;

        [TestInitialize]
        public void setup()
        {
            _head = 0;
            _tail = new List<int> {1, 2, 3};
            _withTail = new NonEmptyList<int>(_head, _tail);
            _noTail = new NonEmptyList<int>(_head);
        }

        [TestMethod]
        public void Head_IsSetCorrectly()
        {
            Assert.AreEqual(_noTail.Head, _head);
        }

        [TestMethod]
        public void Tail_IsEmpty()
        {
            Assert.IsFalse(_noTail.Tail.Any());
        }

        [TestMethod]
        public void Tail_ContainsTheCorrectElements()
        {
            CollectionAssert.AreEqual(_withTail.Tail.ToList(), _tail);
        }

        [TestMethod]
        public void Remove_NeverEmptiesTheList()
        {
            Assert.IsFalse(_noTail.Remove(_head));
            Assert.AreEqual(_noTail.Count, 1);
        }

        [TestMethod]
        public void Remove_RemovesElementsIfThereAreMultiple()
        {
            var length = _withTail.Count;
            Assert.IsTrue(_withTail.Remove(_head));
            Assert.AreEqual(_withTail.Count, length - 1);
        }

        [TestMethod]
        public void RemoveAt_HandlesIndexOutOfRange()
        {
            Assert.IsFalse(_noTail.Remove(2));
            Assert.AreEqual(_noTail.Count, 1);
        }
    }
}
