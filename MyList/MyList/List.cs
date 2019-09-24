using System;
using System.Collections;
using System.Collections.Generic;

namespace MyList
{
	class List<T> : IList<T>, IList, ICollection<T>, ICollection, IEnumerable<T>, IEnumerable
	{
		private T[] list;

		public T this[int index]
		{
			get => list[index];
			set
			{
				if (value is T)
				{
					list[index] = value;
				}
				throw new ArgumentException();
			}
		}

		object IList.this[int index]
		{
			get => list[index];
			set
			{
				if (value is T)
				{
					list[index] = (T)value;
				}
				throw new ArgumentException();
			}
		}

		public int Count { get; private set; }

		public int Capacity { get; private set; }

		public bool IsReadOnly => false;

		bool IList.IsFixedSize => false;

		object ICollection.SyncRoot => this;

		bool ICollection.IsSynchronized => false;

		public List()
		{
			Capacity = 8;
			list = new T[Capacity];
			Count = 0;
		}

		public List(int capacity)
		{
			Capacity = capacity;
			list = new T[Capacity];
			Count = 0;
		}

		public List(ICollection<T> collection)
		{
			Capacity = collection.Count;
			Count = Capacity;
			list = new T[Capacity];
			int index = 0;
			foreach (var item in collection)
			{
				list[index] = item;
				index++;
			}
		}

		public void Add(T item)
		{
			if (Count == Capacity)
			{
				ChangeArray();
			}
			list[Count] = item;
			Count++;
		}

		int IList.Add(object value)
		{
			if (value is T)
			{
				Add((T)value);
				return Count;
			}
			throw new ArgumentException();
		}

		public void AddRange(ICollection<T> collection)
		{
			int capacity = Capacity;
			int exponent = 1;
			while (capacity <= Count + collection.Count)
			{
				capacity *= 2;
				exponent++;
			}
			ChangeArray(exponent);
			foreach (var item in collection)
			{
				list[Count] = item;
				Count++;
			}
		}

		public void Clear()
		{
			for (int i = 0; i < Count; i++)
			{
				list[i] = default;
			}
			Count = 0;
		}

		public bool Contains(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (list[i].Equals(item))
				{
					return true;
				}
			}
			return false;
		}

		bool IList.Contains(object value)
		{
			if (value is T)
			{
				return Contains((T)value);
			}
			throw new ArgumentException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			for (int i = 0; i < Count; i++)
			{
				array[arrayIndex] = list[i];
				arrayIndex++;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array is T[])
			{
				CopyTo((T[])array, index);
				return;
			}
			throw new ArgumentException();
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)list).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<T>)list).GetEnumerator();
		}

		public int IndexOf(T item)
		{
			for (int i = 0; i < Count; i++)
			{
				if (list[i].Equals(item))
				{
					return i;
				}
			}
			return -1;
		}

		int IList.IndexOf(object value)
		{
			if (value is T)
			{
				return IndexOf((T)value);
			}
			throw new ArgumentException();
		}

		public void Insert(int index, T item)
		{
			if (index < 0 || index >= Capacity)
			{
				throw new ArgumentOutOfRangeException();
			}
			if (Count == Capacity)
			{
				ChangeArray();
			}
			for (int i = Count; i > index; i--)
			{
				list[i] = list[i - 1];
			}
			list[index] = item;
		}

		void IList.Insert(int index, object value)
		{
			if (value is T)
			{
				Insert(index, (T)value);
				return;
			}
			throw new ArgumentException();
		}

		public bool Remove(T item)
		{
			int index = IndexOf(item);
			if (index == -1)
			{
				throw new ArgumentException();
			}
			if (index == Count - 1)
			{
				Count--;
				return true;
			}
			for (int i = index; i < Count - 1; i++)
			{
				list[i] = list[i++];
			}
			Count--;
			return true;
		}

		void IList.Remove(object value)
		{
			if (value is T)
			{
				Remove((T)value);
				return;
			}
			throw new ArgumentException();
		}

		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentException();
			}
			if (index == Count - 1)
			{
				Count--;
			}
			for (int i = index; i < Count - 1; i++)
			{
				list[i] = list[i++];
			}
			Count--;
		}

		private void ChangeArray()
		{
			var newCapacity = Capacity * 2;
			var newArray = new T[newCapacity];
			IncreaseArray(newArray);
		}

		private void ChangeArray(int exponent)
		{
			var newCapacity = Capacity * (int)Math.Pow(2, exponent);
			var newArray = new T[newCapacity];
			IncreaseArray(newArray);
		}

		private int IncreaseArray(T[] newArray)
		{
			for (int i = 0; i < Capacity; i++)
			{
				newArray[i] = list[i];
			}
			list = newArray;
			return Capacity = list.Length;
		}
	}
}
