using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Task13
{
    class Crew : IList<Worker>
    {
        private Worker[] arr;
        public int Capacity { get => arr.Length; }
        public int Count { get; private set; }
        public Crew()
        {
            Count = 0;
            arr = new Worker[5];
        }
        public Crew(int c)
        {
            Count = 0;
            arr = new Worker[c];
        }
        private void TryResize()
        {
            if(Count == Capacity)
            {
                Worker[] newArr = new Worker[arr.Length * 2];
                for (int i = 0; i < arr.Length; i++)
                    newArr[i] = arr[i];
                arr = newArr;
            }
        }
        public Worker this[int index] 
        { 
            get
            {
                if (index >= 0 && index < Count)
                    return arr[index];
                else
                    throw new IndexOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Count)
                    arr[index] = value;
            }
        }

        public bool IsReadOnly => false;

        public void Add(Worker item)
        {
            TryResize();
            arr[Count++] = item;
        }

        public void Clear()
        {
            Count = 0;
            arr = new Worker[5];
        }

        public bool Contains(Worker item)
        {
            for(int i = 0; i < Count; i++)
                if(arr[i].Equals(item))
                    return true;
            return false;
        }

        public void CopyTo(Worker[] array, int arrayIndex)
        {
            if (arrayIndex < 0 || arrayIndex >= Count)
                throw new IndexOutOfRangeException();
            for (int i = 0; i < array.Length; i++)
            {
                if (arrayIndex < Count)
                    array[i] = arr[arrayIndex++];
                else
                    array[i] = new Worker();
            }
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            for(int i = 0; i < Count; i++)
                yield return arr[i];
        }

        public int IndexOf(Worker item)
        {
            for (int i = 0; i < Count; i++)
                if (arr[i].Equals(item))
                    return i;
            return -1;
        }

        public void Insert(int index, Worker item)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            TryResize();
            Worker[] nArr = new Worker[++Count];
            for (int i = 0; i < index; i++)
                nArr[i] = arr[i];
            nArr[index] = item;
            for (int i = index; i < Count-1; i++)
                nArr[i + 1] = arr[i];
            arr = nArr;
        }

        public bool Remove(Worker item)
        {
            for(int i = 0; i < Count; i++)
            {
                if(arr[i].Equals(item))
                {
                    for(int j = i; j < Count-1; j++)
                        arr[j] = arr[j + 1];
                    Count--;
                    return true;
                }
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();
            Count -= 1;
            for (int i = index; i < Count; i++)
                arr[i] = arr[i + 1];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arr.GetEnumerator();   
        }

        public void Sort(IComparer<Worker> ic)
        {
            Worker temp;
            for(int i = 0; i < Count-1; i++)
            {
                for(int j = i+1; j<Count; j++)
                {
                    if(ic.Compare(arr[i],arr[j]) == 1)
                    {
                        temp = arr[i];
                        arr[i] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }
    }
}
