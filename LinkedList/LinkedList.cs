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

        public void AddToOrigin(int n)
        {
            Node newNode = new Node(n);
            newNode.Next = _root;
            _root = newNode;
            Length++;
        }

        public void AddToOrigin(int[] arr)
        {
            if (arr.Length != 0)
            {
                Node crnt = new Node(arr[0]);
                Node tmp = crnt;
                for (int i = 1; i < arr.Length; i++)
                {
                    crnt.Next = new Node(arr[i]);
                    crnt = crnt.Next;
                }
                crnt.Next = _root;
                _root = tmp;
                Length += arr.Length;
            }
        }

        public void AddToIndex(int index, int n)
        {
            if (index == 0)
                AddToOrigin(n);
            else if (index < Length)
            {
                Node newNode = new Node(n);
                Node crnt = _root;
                for (int i = 0; i < index - 1; i++)
                {
                    crnt = crnt.Next;
                }
                newNode.Next = crnt.Next;
                crnt.Next = newNode;
                Length++;
            }
            else if (index == Length)
                Add(n);
        }

        public void AddToIndex(int index, int[] arr)
        {
            if (arr.Length != 0 && index != 0)
            {
                LinkedList inserting_list = new LinkedList(arr);
                Node crnt = GetLastNode(index);
                Node last_of_insering_list = inserting_list.GetLastNode();
                last_of_insering_list.Next = crnt.Next;
                crnt.Next = inserting_list.GetFirstNode();
            }
            else if (arr.Length != 0 && index == 0)
            {
                LinkedList inserting_list = new LinkedList(arr);
                inserting_list.GetLastNode().Next = _root;
                _root = inserting_list.GetFirstNode();
            }
            Length += arr.Length;
        }

        public void Delete(int num = 1)
        {
            if (num >= Length)
            {
                _root = null;
                Length = 0;
            }
            else
            {
                GetLastNode(Length - num).Next = null;
                Length -= num;
            }
        }

        public void DeleteFromOrigin(int num = 1)
        {
            if (Length != 0 && num < Length)
            {
                _root = GetNode(num + 1);
                Length -= num;
            }
            else
                Clean();
        }

        public void DeleteFromIndex(int index, int num = 1)
        {
            if (num == 0)
                return;
            if (index + num > Length)
                num = Length - index;
            if (index >= Length || index < 0)
                throw new NullReferenceException();
            if (Length != 0 && num < Length)
            {
                if (index == 0)
                    _root = GetNode(num + 1);
                else
                {
                    Node crnt = GetNode(index);
                    crnt.Next = GetNode(index + num + 1);
                }
                Length -= num;
            }
            else
                Clean();
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

        private Node GetNode(int index)
        {
            Node crnt = _root;
            for (int i = 0; i < index - 1; i++)
            {
                crnt = crnt.Next;
            }
            return crnt;
        }
        private Node GetFirstNode() { return _root; }

        private Node GetLastNode()
        {
            Node crnt = _root;
            for (int i = 0; i < Length - 1; i++)
            {
                crnt = crnt.Next;
            }    
            return crnt;
        }

        private Node GetLastNode(int length)
        {
            Node crnt = _root;
            for (int i = 0; i < length - 1; i++)
            {
                crnt = crnt.Next;
            }
            return crnt;
        }

        private void Clean()
        {
            _root = null;
            Length = 0;
        }
    }
}
