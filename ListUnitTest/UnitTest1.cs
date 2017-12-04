using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyListImpl;

namespace ListUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldReturnElementsOfListCorrectly()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(1, list[0]);
            Assert.AreEqual(6, list[5]);
            Assert.AreEqual(4, list[3]);
        }

        [TestMethod]
        public void ShouldSetElementsOfListCorrectly()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            list[0] = 10;
            list[5] = 60;
            list[3] = 40;
            Assert.AreEqual(10, list[0]);
            Assert.AreEqual(60, list[5]);
            Assert.AreEqual(40, list[3]);
        }

        [TestMethod]
        public void ShouldReturnCountOfElementsCorrectly()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(6, list.Count);
            list = new MyList<int>();
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ShouldAddNewElementsCorrectly()
        {
            IList<int>list = new MyList<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);
            Assert.AreEqual("0, 1, 2", list.ToString());
        }

        [TestMethod]
        public void ShouldClearListCorrectly()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            list.Clear();
            Assert.AreEqual("", list.ToString());
            Assert.AreEqual(0, list.Count);
        }

        [TestMethod]
        public void ShouldCheckWhetherListContainsSpecifiedElement()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            Assert.AreEqual(true, list.Contains(1));
            Assert.AreEqual(true, list.Contains(3));
            Assert.AreEqual(true, list.Contains(6));
            Assert.AreEqual(false, list.Contains(100));
        }

        [TestMethod]
        public void ShouldCopyToArrayCorrectly()
        {
            IList<int> list = MyList<int>.fromArray(new int[] { 1, 2, 3, 4, 5, 6 });
            int[] array = new int[6];
            list.CopyTo(array, 0);
            Assert.AreEqual("1 2 3 4 5 6", String.Join(" ", array));
            array = new int[10];
            list.CopyTo(array, 3);
            Assert.AreEqual("0 0 0 1 2 3 4 5 6 0", String.Join(" ", array));
        }

        [TestMethod]
        public void ShouldReturnIndexOfElement()
        {
            IList<String> list = MyList<String>.fromArray(
                new String[] {"a", "b", "c", "d", "a", "b"});
            Assert.AreEqual(0, list.IndexOf("a"));
            Assert.AreEqual(1, list.IndexOf("b"));
            Assert.AreEqual(3, list.IndexOf("d"));
            Assert.AreEqual(-1, list.IndexOf("z"));
        }

        [TestMethod]
        public void ShouldInsertElementCorrectly()
        {
            IList<String> list = MyList<String>.fromArray(
                new String[] { "a", "b", "c", "d"});
            list.Insert(0, "z");
            Assert.AreEqual("z, a, b, c, d", list.ToString());

            list.Insert(list.Count - 1, "w");
            Assert.AreEqual("z, a, b, c, w, d", list.ToString());

            list.Insert(2, "y");
            Assert.AreEqual("z, a, y, b, c, w, d", list.ToString());
        }

        [TestMethod]
        public void ShouldRemoveByElement()
        {
            IList<String> list = MyList<String>.fromArray(
                new String[] { "a", "b", "c", "d", "a" });
            Assert.AreEqual(true, list.Remove("a"));
            Assert.AreEqual("b, c, d, a", list.ToString());

            Assert.AreEqual(true, list.Remove("a"));
            Assert.AreEqual("b, c, d", list.ToString());

            Assert.AreEqual(true, list.Remove("c"));
            Assert.AreEqual("b, d", list.ToString());

            Assert.AreEqual(false, list.Remove("a"));
        }

        [TestMethod]
        public void ShouldRemoveByIndex()
        {
            IList<String> list = MyList<String>.fromArray(
                new String[] { "a", "b", "c", "d", "a" });
            list.RemoveAt(0);
            Assert.AreEqual("b, c, d, a", list.ToString());

            list.RemoveAt(list.Count-1);
            Assert.AreEqual("b, c, d", list.ToString());

            list.RemoveAt(1);
            Assert.AreEqual("b, d", list.ToString());
        }

        [TestMethod]
        public void ShouldHandleWithIteratorCorrectly()
        {
            IList<String> list = MyList<String>.fromArray(
                new String[] { "a", "b", "c", "d", "a" });
            IEnumerator<String> iterator = list.GetEnumerator();
            StringBuilder stringBuilder = new StringBuilder();
            while (iterator.MoveNext())
            {
                stringBuilder.Append(iterator.Current).Append(", "); 
            }
            stringBuilder.Remove(stringBuilder.Length - 2, 2);
            Assert.AreEqual(list.ToString(), stringBuilder.ToString());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenIncorrectIndex()
        {
            IList<String> list = MyList<String>.fromArray(
              new String[] { "a", "b", "c", "d", "a" });
            String s = list[5];
        }
    }
}
