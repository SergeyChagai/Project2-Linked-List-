using System;

namespace DataStructures
{
    public class LinkedList
    {
        private Node _root;
        public int Length { get; private set; }

        public LinkedList()
        {
            _root = null;
            Length = 0;
        }
        public LinkedList(int n)
        {
            Node newNode = new Node(n);
            _root = newNode;
            newNode.Next = null;
            Length = 1;
        }
        public LinkedList(int[] array)
        {
            Length = array.Length;

            if (Length != 0)
            {
                _root = new Node(array[0]);
                Node crnt = _root;
                for (int i = 1; i < Length; i++)
                {
                    crnt.Next = new Node(array[i]);
                    crnt = crnt.Next;
                }
            }
            else
                _root = null;
        }

        public void Add(int n)
        {
            if (Length == 0)
            {
                Node newNode = new Node(n);
                _root = newNode;
                newNode.Next = null;
                Length = 1;
            }
            else
            {
                Node tmp = _root;
                for (int i = 0; i < Length - 1; i++)
                    tmp = tmp.Next;
                Node newNode = new Node(n);
                tmp.Next = newNode;
                Length++;
            }
        }

        public void Add(int[] array)
        {
            if (Length == 0 && array.Length != 0)
                _root = new Node(array[0]);

            Node tmp = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                tmp = tmp.Next;
            }
            for (int i = 0; i < array.Length; i++)
            {
                tmp.Next = new Node(array[i]);
                tmp = tmp.Next;
            }

            if (Length == 0 && array.Length != 0)
                _root = _root.Next;

            Length += array.Length;
        }


        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= Length)
                    throw new IndexOutOfRangeException();
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
            set
            {
                if (index < 0 || index > Length)
                    throw new IndexOutOfRangeException();
                if (index == Length)
                    Add(value);
                Node tmp = _root;
                for (int i = 0; i < index; i++)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }

        public override bool Equals(object obj)
        {
            LinkedList linkedList = (LinkedList)obj;

            if (Length != linkedList.Length)
                return false;
            for (int i = 0; i < Length; i++)
            {
                if (this[i] != linkedList[i])
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < Length; i++)
            {
                s = s + this[i] + ";";
            }
            return s;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
