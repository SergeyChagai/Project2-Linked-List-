using DataStructures;
using NUnit.Framework;
using System;

namespace Linked_List.Tests
{
    public class Tests
    {
        [TestCase(1, 0, 1)]
        [TestCase(1, 1, 2)]
        [TestCase(1, 2, 3)]
        [TestCase(1, 3, 4)]
        [TestCase(1, 4, 5)]
        public void GetByIndex(int case_of_list, int index, int expected)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int actual = list[index];
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1)]
        [TestCase(1, 1000)]
        public void GetByIndexNegative(int case_of_list, int index)
        {
            LinkedList list = LinkedListMock(case_of_list);
            int a;
            Assert.Throws<IndexOutOfRangeException>(() =>  a = list[index]) ;
        }

        [TestCase(1, 0, 10, 1)]
        [TestCase(1, 0, -10, 6)]
        [TestCase(2, 4, 10, 2)]
        [TestCase(3, 0, 10, 3)]
        [TestCase(4, 1, 10, 4)]
        [TestCase(5, 6, 10, 5)]
        public void SetToIndex(int case_of_list, int index, int value, int case_of_exp_list)
        {
            LinkedList expected = SetToIndexExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual[index] = value;
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, -1)]
        [TestCase(1, 1000)]
        public void SetToIndexNegative(int case_of_list, int index)
        {
            LinkedList list = LinkedListMock(case_of_list);
            Assert.Throws<IndexOutOfRangeException>(() => list[index] = 1);
        }


        [TestCase(1, 10, 1)]
        [TestCase(2, 0, 2)]
        [TestCase(3, int.MaxValue, 3)]
        [TestCase(4, int.MinValue, 4)]
        [TestCase(5, -10, 5)]
        public void Add(int case_of_list, int value, int case_of_exp_list)
        {
            LinkedList expected = AddExpectedMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Add(value);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, new int[] { 10, 20 }, 1)]
        [TestCase(2, new int[] { }, 2)]
        [TestCase(3, new int[] { 10, 20}, 3)]
        [TestCase(4, new int[] { int.MaxValue, int.MinValue }, 4)]
        public void Add(int case_of_list, int[] array, int case_of_exp_list)
        {
            LinkedList expected = AddArrayMock(case_of_exp_list);
            LinkedList actual = LinkedListMock(case_of_list);

            actual.Add(array);
            Assert.AreEqual(expected, actual);
        }

        public LinkedList LinkedListMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30});
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddArrayMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5, 10, 20 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 10, 20 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, int.MaxValue, int.MinValue});
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList SetToIndexExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 10, 2, 3, 4, 5 });
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 10 });
                    return list;
                case 3:
                    list = new LinkedList(new int[] { 10 });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, 10 });
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30, 10});
                    return list;
                case 6:
                    list = new LinkedList(new int[] { -10, 2, 3, 4, 5 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }

        public LinkedList AddExpectedMock(int a)
        {
            LinkedList list;
            switch (a)
            {
                case 1:
                    list = new LinkedList(new int[] { 1, 2, 3, 4, 5, 10});
                    return list;
                case 2:
                    list = new LinkedList(new int[] { 5, 4, 3, 2, 1, 0});
                    return list;
                case 3:
                    list = new LinkedList(new int[] { int.MaxValue });
                    return list;
                case 4:
                    list = new LinkedList(new int[] { 1, int.MinValue});
                    return list;
                case 5:
                    list = new LinkedList(new int[] { 10, 5, 10, 20, 40, 30, -10 });
                    return list;
                default:
                    throw new ArgumentException();
            }
        }
    }
}