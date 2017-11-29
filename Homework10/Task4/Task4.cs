using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    /// <summary>
    /// Develop a generic class-collection Queue that implements the basic operations for working with the stucture data queue. 
    /// Implement the capability to iterate by collection by design pattern Iterator. Develop unit-tests.
    /// </summary>
    class Task4
    {
        static void Main(string[] args)
        {
        }
    }

    public class CustomQueue<T> : ICustomQueue<T>
    {
        List<T> _list = new List<T>();

        public T this[int index]
        {
            get => _list[index];
        }
        public T Dequeue()
        {
            T elem = _list[0];
            _list.RemoveAt(0);
            return elem;
        }
        public void Enqueue(T elem)
        {
            _list.Add(elem);
        }
        public ICustomQueueEnumerator<T> GetIterator()
        {
            return new CustomQueueEnumerator<T>(this);
        }
        public T Peek()
        {
            T elem = _list[0];
            return elem;
        }
        public int Length
        {
            get => _list.Count;
        }
    }

    public class CustomQueueEnumerator<T> : ICustomQueueEnumerator<T>
    {
        CustomQueue<T> _customQueueInstance;
        int _currentIndex;

        public CustomQueueEnumerator(CustomQueue<T> customQueueInstance)
        {
            if (customQueueInstance == null) throw new ArgumentNullException(nameof(customQueueInstance), "argument should not be null");
            _customQueueInstance = customQueueInstance;
        }
        public T Current
        {
            get => _customQueueInstance[_currentIndex];
        }
        public T MoveNext()
        {
            _currentIndex++;
            if (_currentIndex < _customQueueInstance.Length)
            {
                return _customQueueInstance[_currentIndex];
            }
            else
            {
                return default(T);
            }
        }
        public void Reset()
        {
            _currentIndex = 0;
        }
    }

    public interface ICustomQueue<T>
    {
        ICustomQueueEnumerator<T> GetIterator();
        void Enqueue(T elem);
        T Dequeue();
        T Peek();
        T this[int index] { get;}
        int Length { get; }
    }

    public interface ICustomQueueEnumerator<out T>
    {
        T Current { get; }
        T MoveNext();
        void Reset();
    }
}
